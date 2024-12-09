using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action OnFailGame;

    private bool isActivate = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivate) return;

        if(collision.gameObject.TryGetComponent<Item>(out var item))
        {
            OnFailGame?.Invoke();
        }
    }

    public void Activate()
    {
        isActivate = true;
    }

    public void Deactivate()
    {
        isActivate = false;
    }
}
