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
        fakeItemInput.OnPointerDown_Action += PointerDown;
        fakeItemInput.OnPointerUp_Action += PointerUp;
        fakeItemInput.OnPointerMove_Action += PointerMove;
    }

    public void Dispose()
    {
        fakeItemInput.OnPointerDown_Action -= PointerDown;
        fakeItemInput.OnPointerUp_Action -= PointerUp;
        fakeItemInput.OnPointerMove_Action -= PointerMove;
    }

    public void Activate()
    {
        fakeItem.Activate();
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
        Debug.Log("MOVE");

        vectorX = Mathf.Clamp(vector.x, leftBoundary.position.x, rightBoundary.position.x);
    }

    public void Teleport(Vector3 vector)
    {
        Debug.Log("TELEPORT");

        vectorX = Mathf.Clamp(vector.x, leftBoundary.position.x, rightBoundary.position.x);

        fakeItem.Move(vectorX);
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
        Debug.Log(vectorX);

        fakeItem.Move(Mathf.SmoothDamp(fakeItem.Position.x, vectorX, ref velocity.x, smoothTime));
    }

    #region Input

    public event Action<PointerEventData> OnPointerDown;
    public event Action<PointerEventData> OnPointerUp;
    public event Action<PointerEventData> OnPointerMove;

    private void PointerDown(PointerEventData eventData)
    {
        OnPointerDown?.Invoke(eventData);
    }

    private void PointerUp(PointerEventData eventData)
    {
        OnPointerUp?.Invoke(eventData);
    }

    private void PointerMove(PointerEventData eventData)
    {
        OnPointerMove?.Invoke(eventData);
    }

    #endregion
}
