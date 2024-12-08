using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FakeItemMoveModel
{
    public event Action OnActivate;
    public event Action OnDeactivate;

    public event Action OnStartMove;
    public event Action<Vector3> OnTeleport;
    public event Action<Vector3> OnMove;
    public event Action OnEndMove;
    public event Action<Vector3> OnEndMove_Position;

    public event Action<ItemData> OnSetData;

    private bool isActive = false;

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

        if (!isActive) return;

        OnTeleport?.Invoke(pointerEventData.position);
    }

    public void Move(PointerEventData pointerEventData)
    {
        if (!isActive) return;

        OnMove?.Invoke(pointerEventData.position);
    }

    public void EndMove(PointerEventData pointerEventData, Vector3 vectorItemPosition)
    {
        if (!isActive) return;

        Deactivate();

        OnEndMove_Position?.Invoke(vectorItemPosition);
        OnEndMove?.Invoke();
    }


    public void Activate()
    {
        isActive = true;

        OnActivate?.Invoke();
    }

    public void Deactivate()
    {
        isActive = false;

        OnDeactivate?.Invoke();
    }

}
