using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModesState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public ModesState(
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
        sceneRoot.OnBack_ModesPanel += ChangeStateToPause;

        sceneRoot.OpenModesPanel();
    }

    public void ExitState()
    {
        sceneRoot.OnBack_ModesPanel -= ChangeStateToPause;

        sceneRoot.CloseModesPanel();
    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }
}
