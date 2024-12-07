using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FakeItemInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event Action<PointerEventData> OnPointerDown_Action;
    public event Action<PointerEventData> OnPointerUp_Action;
    public event Action<PointerEventData> OnPointerMove_Action;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDown_Action?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUp_Action?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnPointerMove_Action?.Invoke(eventData);
    }
}
