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
    private ISound soundFailGame;

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

        soundFailGame = soundProvider.GetSound("FailGame");
    }

    public void EnterState()
    {
        fakeItemMovePresenter.OnStartMove += ChangeStateToGame;

        soundFailGame.PlayOneShot();

        sceneRoot.OpenPausePanels();

        soundFailGame.Play();
        soundFailGame.SetVolume(0, 0.6f);

        itemsPresenter.ActivateAnimationFail();
    }

    public void ExitState()
    {
        fakeItemMovePresenter.OnStartMove -= ChangeStateToGame;

        itemsPresenter.RemoveAllItems();
        sceneRoot.ClosePausePanels();

        soundFailGame.SetVolume(0.6f, 0, soundFailGame.Stop);
    }

    private void ChangeStateToGame()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }
}
