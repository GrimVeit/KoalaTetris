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
    private ISoundProvider soundProvider;
    private ISound soundBackgroundStart;

    public StartState(
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

        soundBackgroundStart = this.soundProvider.GetSound("Background_Start");
    }

    public void EnterState()
    {
        soundBackgroundStart.Play();
        soundBackgroundStart.SetVolume(0, 0.4f);

        sceneRoot.OpenMainMenuPanel();

        fakeItemMovePresenter.OnEndMove += ChangeStateToGame;
    }

    public void ExitState()
    {
        soundBackgroundStart.SetVolume(0.4f, 0, soundBackgroundStart.Stop);

        sceneRoot.OpenGamePanel();

        fakeItemMovePresenter.OnEndMove -= ChangeStateToGame;
    }

    private void ChangeStateToGame()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }
}
