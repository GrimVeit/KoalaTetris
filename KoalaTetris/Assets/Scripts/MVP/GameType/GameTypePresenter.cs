using System;
using UnityEngine;

public class GameTypePresenter
{
    private GameTypeModel model;
    private GameTypesView view;

    public GameTypePresenter(GameTypeModel model, GameTypesView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        model.Initialize();
        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        model.Dispose();
        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnChooseType += model.ChooseTypeGame;
    }

    private void DeactivateEvents()
    {
        view.OnChooseType -= model.ChooseTypeGame;
    }

    #region Input

    public event Action<GameType> OnChooseGameType_Value
    {
        add { model.OnChooseGameType_Value += value; }
        remove { model.OnChooseGameType_Value -= value; }
    }

    public event Action OnChooseGameType
    {
        add { model.OnChooseGameType += value; }
        remove { model.OnChooseGameType -= value; }
    }

    #endregion
}
