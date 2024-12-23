using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private BonusPresenter bonusPresenter;

    private ScorePresenter scorePresenter;
    private GameTypePresenter gameTypePresenter;

    private IGlobalStateMachineControl globalStateMachineControl;
    private ISoundProvider soundProvider;

    public BonusState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        ISoundProvider soundProvider,
        BonusPresenter bonusPresenter,
        ScorePresenter scorePresenter,
        GameTypePresenter gameTypePresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.soundProvider = soundProvider;
        this.bonusPresenter = bonusPresenter;
        this.scorePresenter = scorePresenter;
        this.gameTypePresenter = gameTypePresenter;
    }

    public void EnterState()
    {
        sceneRoot.OnClickToNoThankOpenBonusPanel_ChoosebonusPanel += ChangeStateToPause;
        sceneRoot.OnClickToOpenBonusPanel_ChooseBonusPanel += sceneRoot.OpenBonusPanel;
        sceneRoot.OnClickToOpenBonusPanel_ChooseBonusPanel += sceneRoot.CloseChooseBonusFooterPanel;
        sceneRoot.OnBack_BonusPanel += sceneRoot.OpenChooseBonusFooterPanel;
        sceneRoot.OnBack_BonusPanel += sceneRoot.CloseBonusPanel;

        bonusPresenter.OnActivateSpin += sceneRoot.OpenBlockPanel;
        bonusPresenter.OnBonusDesign += CheckBonusDesign;
        bonusPresenter.OnBonusScore += CheckBonusScore;

        bonusPresenter.ClearResult();
        sceneRoot.OpenChooseBonusFooterPanel();
        bonusPresenter.SetAvailable();

    }

    public void ExitState()
    {
        sceneRoot.OnClickToNoThankOpenBonusPanel_ChoosebonusPanel -= ChangeStateToPause;
        sceneRoot.OnClickToOpenBonusPanel_ChooseBonusPanel -= sceneRoot.OpenBonusPanel;
        sceneRoot.OnClickToOpenBonusPanel_ChooseBonusPanel -= sceneRoot.CloseChooseBonusFooterPanel;
        sceneRoot.OnBack_BonusPanel -= sceneRoot.OpenChooseBonusFooterPanel;
        sceneRoot.OnBack_BonusPanel -= sceneRoot.CloseBonusPanel;

        bonusPresenter.OnActivateSpin -= sceneRoot.OpenBlockPanel;
        bonusPresenter.OnBonusDesign -= CheckBonusDesign;
        bonusPresenter.OnBonusScore -= CheckBonusScore;

        sceneRoot.CloseGameHeaderPanel();
        sceneRoot.CloseChooseBonusFooterPanel();
        bonusPresenter.SetUnvailable();
    }

    private void ChangeStateToPause()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }

    private void CheckBonusScore(int value)
    {
        if(value == 0 || scorePresenter.CurrentScore == 0)
        {
            ChangeStateToBonusNone();
        }
        else
        {
            ChangeStateToBonusScore();
        }
    }

    private void CheckBonusDesign(int value)
    {
        if (gameTypePresenter.IsOpenTypeGame(value))
        {
            ChangeStateToBonusNone();
        }
        else
        {
            ChangeStateToBonusDesign();
        }
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

    private void ChangeStateToBonusNone()
    {
        soundProvider.PlayOneShot("Button");

        globalStateMachineControl.SetState(globalStateMachineControl.GetState<BonusNoneState>());
    }
}
