using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private BonusPresenter bonusPresenter;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public BonusState(
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
        sceneRoot.OnClickToNoThankOpenBonusPanel_ChoosebonusPanel += ChangeStateToPause;
        sceneRoot.OnClickToOpenBonusPanel_ChooseBonusPanel += sceneRoot.OpenBonusPanel;
        sceneRoot.OnBack_BonusPanel += sceneRoot.OpenChooseBonusFooterPanel;
        sceneRoot.OnBack_BonusPanel += sceneRoot.CloseBonusPanel;

        bonusPresenter.OnBonusDesign += ChangeStateToBonusDesign;
        bonusPresenter.OnBonusScore += ChangeStateToBonusScore;

        sceneRoot.OpenChooseBonusFooterPanel();
        bonusPresenter.SetAvailable();

    }

    public void ExitState()
    {
        sceneRoot.OnClickToNoThankOpenBonusPanel_ChoosebonusPanel -= ChangeStateToPause;
        sceneRoot.OnClickToOpenBonusPanel_ChooseBonusPanel -= sceneRoot.OpenBonusPanel;
        sceneRoot.OnBack_BonusPanel -= sceneRoot.OpenChooseBonusFooterPanel;
        sceneRoot.OnBack_BonusPanel -= sceneRoot.CloseBonusPanel;

        bonusPresenter.OnBonusDesign -= ChangeStateToBonusDesign;
        bonusPresenter.OnBonusScore -= ChangeStateToBonusScore;

        sceneRoot.CloseGameHeaderPanel();
        sceneRoot.CloseChooseBonusFooterPanel();
        bonusPresenter.SetUnvailable();
    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }

    private void ChangeStateToBonusScore()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<BonusScoreState>());
    }

    private void ChangeStateToBonusDesign()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<BonusDesignState>());
    }
}
