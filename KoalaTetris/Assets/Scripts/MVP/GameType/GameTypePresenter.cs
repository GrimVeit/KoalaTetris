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
        view.OnChooseType += model.SelectGame;
        view.OnOpenGame += model.UnlockGame;

        model.OnOpenGameType += view.OpenGame;
    }

    private void DeactivateEvents()
    {
        view.OnChooseType -= model.SelectGame;
        view.OnOpenGame -= model.UnlockGame;

        model.OnOpenGameType -= view.OpenGame;
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

    public void UnlockGame(int id)
    {
        model.UnlockGame(id);
    }

    public void UnlockGame(Vector3 vector, int idGame, int scale = 1, int timeOut = 0)
    {
        view.SpawnGameTypeEffect(vector, idGame, scale, timeOut);
    }

    public bool IsOpenTypeGame(int id)
    {
        return model.IsOpenTypeGame(id);
    }

    #endregion
}
