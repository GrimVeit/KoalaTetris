using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FakeItemMoveView : View
{
    [SerializeField] private FakeItem fakeItem;
    [SerializeField] private FakeItemInput fakeItemInput;

    [SerializeField] Transform leftBoundary;
    [SerializeField] Transform rightBoundary;
    [SerializeField] private float smoothTime;
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 velocity = Vector3.zero;

    private float vectorX;

    public void Initialize()
    {
        vectorX = (rightBoundary.position.x + leftBoundary.position.x)/2;

        fakeItemInput.OnPointerDown_Action += PointerDown;
        fakeItemInput.OnPointerUp_Action += PointerUp;
        fakeItemInput.OnPointerMove_Action += PointerMove;

        fakeItem.OnActivatedItem += OnActivatedItem;
        fakeItem.OnDeactivatedItem += OnDeactivatedItem;
    }

    public void Dispose()
    {
        fakeItemInput.OnPointerDown_Action -= PointerDown;
        fakeItemInput.OnPointerUp_Action -= PointerUp;
        fakeItemInput.OnPointerMove_Action -= PointerMove;
    }

    public void ActivateSmooth()
    {
        fakeItem.ActivateSmooth();
    }

    public void Activate()
    {
        fakeItem.Activate();
    }

    public void DeactivateSmooth()
    {
        fakeItem.DeactivateSmooth();
    }

    public void Deactivate()
    {
        fakeItem.Deactivate();
    }

    public void SetData(ItemData itemData)
    {
        fakeItem.SetData(itemData);
    }

    public void Move(Vector3 vector)
    {
        //Debug.Log("MOVE");

        vectorX = Mathf.Clamp(vector.x, leftBoundary.position.x + fakeItem.Size.x / 3, rightBoundary.position.x - fakeItem.Size.x / 3);
    }

    public void Teleport(Vector3 vector)
    {
        //Debug.Log("TELEPORT");

        vectorX = Mathf.Clamp(vector.x, leftBoundary.position.x + fakeItem.Size.x / 3, rightBoundary.position.x - fakeItem.Size.x / 3);

        fakeItem.Move(vectorX);
    }

    public void EndMove()
    {

    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    touchCurrentPos = eventData.position;

    //    targetPosition = movableObject.position;
    //    targetPosition.x = touchCurrentPos.x;

    //    targetPosition.x = Mathf.Clamp(targetPosition.x, leftBoundary.position.x, rightBoundary.position.x);

    //    movableObject.position = targetPosition;

    //    Debug.Log("OnPointerDown");
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    Debug.Log("OnDrag");

    //    touchCurrentPos = eventData.position;

    //    targetPosition = movableObject.position;
    //    targetPosition.x = touchCurrentPos.x;

    //    targetPosition.x = Mathf.Clamp(targetPosition.x, leftBoundary.position.x, rightBoundary.position.x);
    //}

    private void Update()
    {
        fakeItem.Move(Mathf.SmoothDamp(fakeItem.Position.x, vectorX, ref velocity.x, smoothTime));
    }

    #region Input

    public event Action OnActivatedItem_Action;
    public event Action OnDeactivatedItem_Action;

    public event Action<PointerEventData> OnPointerDown;
    public event Action<PointerEventData, Vector3> OnPointerUp;
    public event Action<PointerEventData> OnPointerMove;

    private void PointerDown(PointerEventData eventData)
    {
        OnPointerDown?.Invoke(eventData);
    }

    private void PointerUp(PointerEventData eventData)
    {
        OnPointerUp?.Invoke(eventData, fakeItem.Position);
    }

    private void PointerMove(PointerEventData eventData)
    {
        OnPointerMove?.Invoke(eventData);
    }

    private void OnActivatedItem()
    {
        OnActivatedItem_Action?.Invoke();
    }

    private void OnDeactivatedItem()
    {
        OnDeactivatedItem_Action?.Invoke();
    }

    #endregion
}
