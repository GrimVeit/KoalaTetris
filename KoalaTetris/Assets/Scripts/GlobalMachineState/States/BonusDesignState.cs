using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDesignState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private BonusPresenter bonusPresenter;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public BonusDesignState(
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
        sceneRoot.OpenBlockPanel();

        Coroutines.Start(Test());
    }

    public void ExitState()
    {
        sceneRoot.CloseBlockPanel();
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(1);

        sceneRoot.CloseBonusPanel();
        sceneRoot.OpenModesPanel();

        yield return new WaitForSeconds(1);

        bonusPresenter.SubmitBonus();

        yield return new WaitForSeconds(1f);
        sceneRoot.CloseModesPanel();
        ChangeStateToPause();

    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }
}
