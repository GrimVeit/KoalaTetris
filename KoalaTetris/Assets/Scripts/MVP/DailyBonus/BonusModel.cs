using System;
using UnityEngine;

public class BonusModel
{
    public event Action<int> OnBonusScore;
    public event Action<int> OnBonusDesign;

    public event Action<string> OnGetBonusDescription;
    public event Action<Vector3, int, int, int> OnUnlockGame_ID;
    public event Action<Vector3, int, int, int> OnScoreMultiplier_Size;

    public event Action OnAvailableBonusButton;
    public event Action OnUnvailableBonusButton;
    public event Action OnActivateSpin;

    private bool isActive = true;

    private ISoundProvider soundProvider;


    private Transform transformPosition;
    private Bonus currentBonus;
    //private ISound soundSpin;

    public BonusModel(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
        //soundSpin = soundProvider.GetSound("Spin");
    }

    public void Spin()
    {
        if (isActive)
        {
            OnActivateSpin?.Invoke();
            //soundProvider.PlayOneShot("ClickUnlocked");
            //soundSpin.SetVolume(0.4f);
            //soundSpin.SetPitch(1);
            //soundSpin.Play();
            SetUnvailable();
            return;
        }

        //soundProvider.PlayOneShot("ClickLocked");
    }

    public void SetUnvailable()
    {
        isActive = false;

        OnUnvailableBonusButton?.Invoke();
    }

    public void SetAvailable()
    {
        isActive = true;

        OnAvailableBonusButton?.Invoke();
    }

    public void GetBonus(Transform transformDisplay, Bonus bonus)
    {
        soundProvider.PlayOneShot("Success");

        transformPosition = transformDisplay;
        currentBonus = bonus;

        OnGetBonusDescription?.Invoke(bonus.Description);

        if (currentBonus.BonusType == BonusType.ScoreMultiplier)
        {
            OnBonusScore?.Invoke(bonus.Value);
        }
        else
        {
            OnBonusDesign?.Invoke(bonus.Value);
        }
    }

    public void SubmitBonus()
    {
        soundProvider.PlayOneShot("Success");

        if (currentBonus.BonusType == BonusType.ScoreMultiplier)
        {
            if (currentBonus.Value != 0)
                OnScoreMultiplier_Size?.Invoke(transformPosition.position, currentBonus.Value, 4, 2);
        }
        else
        {
            OnUnlockGame_ID?.Invoke(transformPosition.position, currentBonus.Value, 2, 2);
        }

        OnGetBonusDescription?.Invoke(currentBonus.Description);
    }

    public void OnSpin(float speed)
    {
        float currentSpeed = speed / 500;

        if (currentSpeed > 0.1f)
        {
            return;
        }

        //soundSpin.SetVolume(currentSpeed / 2);

        float pitch = Mathf.Lerp(1, 0.88f, 1 - currentSpeed);
        //soundSpin.SetPitch(pitch * 1f);
    }

    public void OnEndSpin()
    {
        //soundSpin.Stop();
    }
}
