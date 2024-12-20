using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameTypesButton
{
    [SerializeField] private Button buttonChoose;
    [SerializeField] private int id;

    public void Initialize()
    {
        buttonChoose.onClick.AddListener(HandleChooseType);
    }

    public void Dispose()
    {
        buttonChoose.onClick.RemoveListener(HandleChooseType);
    }

    #region Input

    public event Action<int> OnChooseTypeGame;

    private void HandleChooseType()
    {
        OnChooseTypeGame?.Invoke(id);
    }

    #endregion
}
