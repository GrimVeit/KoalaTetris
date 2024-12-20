using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModesState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private GameTypePresenter gameTypePresenter;
    private ItemsPresenter itemsPresenter;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public ModesState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        ISoundProvider soundProvider,
        GameTypePresenter gameTypePresenter,
        ItemsPresenter itemsPresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.soundProvider = soundProvider;
        this.gameTypePresenter = gameTypePresenter;
        this.itemsPresenter = itemsPresenter;
    }

    public void EnterState()
    {
        sceneRoot.OnBack_ModesPanel += ChangeStateToPause;
        gameTypePresenter.OnChooseGameType += ChangeStateToGame;

        sceneRoot.OpenModesPanel();
    }

    public void ExitState()
    {
        sceneRoot.OnBack_ModesPanel -= ChangeStateToPause;
        gameTypePresenter.OnChooseGameType -= ChangeStateToGame;

        sceneRoot.CloseModesPanel();
    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }

    private void ChangeStateToGame()
    {
        soundProvider.PlayOneShot("Button");

        itemsPresenter.RemoveAllItems();

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }
}
