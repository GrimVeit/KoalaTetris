using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FakeItemMoveModel
{
    public event Action OnActivatedItem;
    public event Action OnDeactivatedItem;

    public event Action OnStartActivateSmooth;
    public event Action OnStartDeactivateSmooth;
    public event Action OnStartActivate;
    public event Action OnStartDeactivate;

    public event Action OnStartMove;
    public event Action<Vector3> OnTeleport;
    public event Action<Vector3> OnMove;
    public event Action OnEndMove;
    public event Action OnSpawn;
    public event Action<Vector3> OnEndMove_Position;

    public event Action<ItemData> OnSetData;

    private bool isActive = false;

    public ISoundProvider soundProvider;

    public FakeItemMoveModel(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void SetData(ItemData itemData)
    {
        OnSetData?.Invoke(itemData);
    }

    public void StartMove(PointerEventData pointerEventData)
    {
        OnStartMove?.Invoke();
        OnTeleport?.Invoke(pointerEventData.position);

        if (!isActive) return;
    }

    public void Move(PointerEventData pointerEventData)
    {
        OnMove?.Invoke(pointerEventData.position);

        if (!isActive) return;
    }

    public void EndMove(PointerEventData pointerEventData, Vector3 vectorItemPosition)
    {
        OnEndMove?.Invoke();

        if (!isActive) return;

        OnEndMove_Position?.Invoke(vectorItemPosition);
        OnSpawn?.Invoke();

        soundProvider.PlayOneShot("Button");

        StartDeactivate();
    }


    public void StartActivateSmooth()
    {
        OnStartActivateSmooth?.Invoke();
    }

    public void StartActivate()
    {
        OnStartActivate?.Invoke();
    }

    public void StartDeactivateSmooth()
    {
        OnStartDeactivateSmooth?.Invoke();
    }

    public void StartDeactivate()
    {
        OnStartDeactivate?.Invoke();
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

}
