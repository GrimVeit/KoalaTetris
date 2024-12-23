using System;
using UnityEngine;

public class BonusPresenter
{
    private BonusModel bonusModel;
    private BonusView bonusView;

    public BonusPresenter(BonusModel dailyBonusModel, BonusView dailyBonusView)
    {
        this.bonusModel = dailyBonusModel;
        this.bonusView = dailyBonusView;
    }

    public void Initialize()
    {
        ActivateEvents();

        bonusView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        bonusView.Dispose();
    }

    private void ActivateEvents()
    {
        bonusView.OnClickSpinButton += bonusModel.Spin;
        bonusView.OnEndSpin += bonusModel.OnEndSpin;
        bonusView.OnGetBonus += bonusModel.GetBonus;

        bonusModel.OnGetBonusDescription += bonusView.DisplayDescription;
        bonusModel.OnActivateSpin += bonusView.StartSpin;
        bonusModel.OnUnvailableBonusButton += bonusView.DeactivateSpinButton;
        bonusModel.OnAvailableBonusButton += bonusView.ActivateSpinButton;
    }

    private void DeactivateEvents()
    {
        bonusView.OnClickSpinButton -= bonusModel.Spin;
        bonusView.OnSpin -= bonusModel.OnSpin;
        bonusView.OnEndSpin -= bonusModel.OnEndSpin;
        bonusView.OnGetBonus -= bonusModel.GetBonus;

        bonusModel.OnGetBonusDescription -= bonusView.DisplayDescription;
        bonusModel.OnActivateSpin -= bonusView.StartSpin;
        bonusModel.OnUnvailableBonusButton -= bonusView.DeactivateSpinButton;
        bonusModel.OnAvailableBonusButton -= bonusView.ActivateSpinButton;
    }

    #region

    public void SetAvailable()
    {
        bonusModel.SetAvailable();
    }

    public void SetUnvailable()
    {
        bonusModel.SetUnvailable();
    }

    //public event Action<int> OnGetBonus
    //{
    //    add { dailyBonusModel.OnGetBonusDescription += value; }
    //    remove { dailyBonusModel.OnGetBonusDescription -= value; }
    //}

    public event Action OnBonusScore
    {
        add { bonusModel.OnBonusScore += value; }
        remove { bonusModel.OnBonusScore -= value; }
    }

    public event Action OnBonusDesign
    {
        add { bonusModel.OnBonusDesign += value; }
        remove { bonusModel.OnBonusDesign -= value; }
    }

    public event Action OnActivateSpin
    {
        add { bonusModel.OnActivateSpin += value; }
        remove { bonusModel.OnActivateSpin -= value; }
    }

    public event Action<int> OnUnlockGame_ID
    {
        add { bonusModel.OnUnlockGame_ID += value; }
        remove { bonusModel.OnUnlockGame_ID -= value; }
    }

    public event Action<Vector3, int, int, int> OnScoreMultiplier_Size
    {
        add { bonusModel.OnScoreMultiplier_Size += value; }
        remove { bonusModel.OnScoreMultiplier_Size -= value; }
    }

    public void SubmitBonus()
    {
        bonusModel.SubmitBonus();
    }

    #endregion
}
