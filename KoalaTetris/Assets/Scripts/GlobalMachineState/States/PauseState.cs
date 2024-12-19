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

    private ISoundProvider soundProvider;

    public PauseState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        ISoundProvider soundProvider,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter,
        ItemSpawnerPresenter itemSpawnerPresenter,
        ItemsPresenter itemsPresenter,
        ScorePresenter scorePresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.soundProvider = soundProvider;
        this.fakeItemMovePresenter = fakeItemMovePresenter;
        this.itemCatalogPresenter = itemCatalogPresenter;
        this.itemSpawnerPresenter = itemSpawnerPresenter;
        this.itemsPresenter = itemsPresenter;
        this.scorePresenter = scorePresenter;
    }

    public void EnterState()
    {
        sceneRoot.OnRestartGame_PauseFooterPanel += ChangeStateToGame;
        sceneRoot.OnOpenModes_PauseFooterPanel += ChangeStateToModes;

        sceneRoot.OpenPausePanels();
    }

    public void ExitState()
    {
        sceneRoot.OnRestartGame_PauseFooterPanel -= ChangeStateToGame;
        sceneRoot.OnOpenModes_PauseFooterPanel -= ChangeStateToModes;

        sceneRoot.ClosePausePanels();
    }

    private void ChangeStateToGame()
    {
        soundProvider.PlayOneShot("Button");

        itemsPresenter.RemoveAllItems();

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }

    private void ChangeStateToModes()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<ModesState>());
    }
}
