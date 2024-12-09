using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZonesView : View
{
    [SerializeField] private List<Trigger> triggers = new List<Trigger>();

    public void Initialize()
    {
        for (int i = 0; i < triggers.Count; i++)
        {
            triggers[i].OnFailGame += HandlerFailGame;
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < triggers.Count; i++)
        {
            triggers[i].OnFailGame -= HandlerFailGame;
        }
    }

    #region Input

    public event Action OnFailGame;

    private void HandlerFailGame()
    {
        OnFailGame?.Invoke();
    }

    #endregion
}
