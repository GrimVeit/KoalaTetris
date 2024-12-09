using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZonesModel : MonoBehaviour
{
    public event Action OnFailGame;

    public void FailGame()
    {
        Debug.Log("FAIL");

        OnFailGame?.Invoke();
    }
}
