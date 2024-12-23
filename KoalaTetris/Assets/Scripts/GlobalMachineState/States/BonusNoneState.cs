using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusNoneState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public BonusNoneState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        ISoundProvider soundProvider)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.soundProvider = soundProvider;
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
        yield return new WaitForSeconds(1f);
        sceneRoot.CloseBonusPanel();
        ChangeStateToPause();

    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }
}
