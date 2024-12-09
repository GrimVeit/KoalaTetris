using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private FakeItemMovePresenter fakeItemMovePresenter;
    private ItemCatalogPresenter itemCatalogPresenter;
    private ItemSpawnerPresenter itemSpawnerPresenter;

    private ItemsPresenter itemsPresenter;
    private ScorePresenter scorePresenter;

    private IGlobalStateMachineControl globalStateMachineControl;

    public StartState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter,
        ItemSpawnerPresenter itemSpawnerPresenter,
        ItemsPresenter itemsPresenter,
        ScorePresenter scorePresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.fakeItemMovePresenter = fakeItemMovePresenter;
        this.itemCatalogPresenter = itemCatalogPresenter;
        this.itemSpawnerPresenter = itemSpawnerPresenter;
        this.itemsPresenter = itemsPresenter;
        this.scorePresenter = scorePresenter;
    }

    public void EnterState()
    {
        sceneRoot.OpenMainMenuPanel();

        fakeItemMovePresenter.OnEndMove += ChangeStateToGame;
    }

    public void ExitState()
    {
        sceneRoot.OpenGamePanel();

        fakeItemMovePresenter.OnEndMove -= ChangeStateToGame;
    }

    private void ChangeStateToGame()
    {
        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }
}
