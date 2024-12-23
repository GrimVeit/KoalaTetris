using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private FakeItemMovePresenter fakeItemMovePresenter;
    private ItemCatalogPresenter itemCatalogPresenter;
    private ItemSpawnerPresenter itemSpawnerPresenter;

    private ScorePresenter scorePresenter;

    private IGlobalStateMachineControl globalStateMachineControl;

    private ISoundProvider soundProvider;
    private ISound soundFailGame;

    public LoseState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        ISoundProvider soundProvider,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter,
        ItemSpawnerPresenter itemSpawnerPresenter,
        ScorePresenter scorePresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.soundProvider = soundProvider;
        this.fakeItemMovePresenter = fakeItemMovePresenter;
        this.itemCatalogPresenter = itemCatalogPresenter;
        this.itemSpawnerPresenter = itemSpawnerPresenter;
        this.scorePresenter = scorePresenter;

        soundFailGame = soundProvider.GetSound("FailGame");
    }

    public void EnterState()
    {
        soundFailGame.PlayOneShot();

        soundFailGame.Play();
        soundFailGame.SetVolume(0, 0.6f, ChangeStateToChooseBonus);
    }

    public void ExitState()
    {
        //soundFailGame.SetVolume(0.6f, 0, soundFailGame.Stop);
    }

    private void ChangeStateToChooseBonus()
    {
        globalStateMachineControl.SetState(globalStateMachineControl.GetState<BonusState>());
    }
}
