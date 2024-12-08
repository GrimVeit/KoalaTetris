using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private FakeItemMovePresenter fakeItemMovePresenter;
    private ItemCatalogPresenter itemCatalogPresenter;
    private ItemSpawnerPresenter itemSpawnerPresenter;

    private ItemsPresenter itemsPresenter;
    private ScorePresenter scorePresenter;

    private IGlobalStateMachineControl globalStateMachineControl;

    public PauseState(
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
        fakeItemMovePresenter.OnStartMove += ChangeStateToGame;

        sceneRoot.OpenPausePanels();
    }

    public void ExitState()
    {
        fakeItemMovePresenter.OnStartMove -= ChangeStateToGame;

        itemsPresenter.RemoveAllItems();
        sceneRoot.ClosePausePanels();
    }

    private void ChangeStateToGame()
    {
        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }
}
