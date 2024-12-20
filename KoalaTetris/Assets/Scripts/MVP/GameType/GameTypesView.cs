using System;
using System.Collections.Generic;
using UnityEngine;

public class GameTypesView : View
{
    [SerializeField] private List<GameTypesButton> gameTypesButtons = new List<GameTypesButton>(); 

    public void Initialize()
    {
        for (int i = 0; i < gameTypesButtons.Count; i++)
        {
            gameTypesButtons[i].OnChooseTypeGame += HandleChooseType;
            gameTypesButtons[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < gameTypesButtons.Count; i++)
        {
            gameTypesButtons[i].OnChooseTypeGame -= HandleChooseType;
            gameTypesButtons[i].Dispose();
        }
    }

    #region Input

    public event Action<int> OnChooseType;

    private void HandleChooseType(int type)
    {
        OnChooseType?.Invoke(type);
    }

    #endregion
}
