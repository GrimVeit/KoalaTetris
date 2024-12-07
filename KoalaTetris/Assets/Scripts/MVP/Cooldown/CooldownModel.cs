using System;
using System.Collections;
using UnityEngine;

public class CooldownModel
{
    public event Action OnSetAvailableButton;
    public event Action OnSetUnvailableButton;

    public event Action OnClickToActivatedButton;
    public event Action OnClickToDeactivatedButton;
    public event Action<string> OnCountdownTimer;

    private string ID;
    private readonly string KEY;

    private TimeSpan timeToReload;
    private DateTime nextRewardTime;
    private bool isRewardAvailable => DateTime.Now >= nextRewardTime;

    //private ISoundProvider soundProvider;
    //private IParticleEffectProvider particleEffectProvider;
    //private IParticleEffect effectReload;

    private IEnumerator countdownButton_coroutine;

    private ISoundProvider soundProvider;

    public CooldownModel(string key, TimeSpan timeToReload, ISoundProvider soundProvider)
    {
        KEY = key;
        this.timeToReload = timeToReload;
        this.soundProvider = soundProvider;
        //this.particleEffectProvider = particleEffectProvider;
    }

    public void Initialize()
    {
        //effectReload = particleEffectProvider.GetParticleEffect(ID);

        Debug.Log("Success");
        nextRewardTime = DateTime.Parse(PlayerPrefs.GetString(KEY, DateTime.Now.ToString()));
        Debug.Log("Success");
    }

    public void Activate()
    {
        ActivateCountdown();
    }

    public void Deactivate()
    {
        DeactivateCountdown();
        //effectReload.Stop();
    }

    public void SetID(string ID)
    {
        this.ID = ID;
    }

    public void Dispose()
    {

    }

    public void ClickButton()
    {
        if (isRewardAvailable)
        {
            OnClickToActivatedButton?.Invoke();
            soundProvider.PlayOneShot("ClickUnlocked");
            return;
        }

        soundProvider.PlayOneShot("ClickLocked");
        OnClickToDeactivatedButton?.Invoke();
    }

    public void ActivateCooldown()
    {
        nextRewardTime = DateTime.Now + timeToReload;
        PlayerPrefs.SetString(KEY, nextRewardTime.ToString());
        ActivateCountdown();

        Debug.Log("������ ������ �������");
        //soundProvider.PlayOneShot("Error");
    }

    private void ActivateCountdown()
    {
        DeactivateCountdown();

        countdownButton_coroutine = Countdown_Coroutine();

        Coroutines.Start(countdownButton_coroutine);
    }

    private void DeactivateCountdown()
    {
        if (countdownButton_coroutine != null)
            Coroutines.Stop(countdownButton_coroutine);
    }

    private IEnumerator Countdown_Coroutine()
    {
        //effectReload.Stop();
        OnSetUnvailableButton?.Invoke();

        while (!isRewardAvailable)
        {
            TimeSpan timeRemaining = nextRewardTime - DateTime.Now;

            if (timeRemaining.TotalSeconds == 0)
            {
                OnSetAvailableButton?.Invoke();
                break;
            }

            OnCountdownTimer?.Invoke(string.Format("{0:D2}:{1:D2}:{2:D2}", timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds));

            yield return new WaitForSeconds(1);
        }

        //soundProvider.PlayOneShot(ID);
        //effectReload.Play();
        OnSetAvailableButton?.Invoke();
    }
}
