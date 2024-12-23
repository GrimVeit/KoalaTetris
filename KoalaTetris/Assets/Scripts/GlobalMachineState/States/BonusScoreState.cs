using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScoreState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private BonusPresenter bonusPresenter;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public BonusScoreState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        ISoundProvider soundProvider,
        BonusPresenter bonusPresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.soundProvider = soundProvider;
        this.bonusPresenter = bonusPresenter;
    }

    public void EnterState()
    {
        sceneRoot.OpenGameHeaderPanel();
        sceneRoot.OpenBlockPanel();

        Coroutines.Start(Test());
    }

    public void ExitState()
    {
        sceneRoot.CloseBlockPanel();
        sceneRoot.CloseGameHeaderPanel();
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(1);

        sceneRoot.CloseBonusPanel();
        bonusPresenter.SubmitBonus();

        yield return new WaitForSeconds(3f);

        ChangeStateToPause();

    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }
}
