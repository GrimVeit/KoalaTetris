using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{

    private Panel currentPanel;

    private ISoundProvider soundProvider;

    public void Initialize()
    {

    }

    public void Activate()
    {

    }

    public void Deactivate()
    {

    }

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void SetParticleEffectProvider(IParticleEffectProvider particleEffectProvider)
    {
        //this.particleEffectProvider = particleEffectProvider;
    }

    public void Dispose()
    {

    }


    private void OpenPanel(Panel panel)
    {
        if (currentPanel != null)
            currentPanel.DeactivatePanel();

        //soundProvider.PlayOneShot("ShoohPanel_Open");
        currentPanel = panel;
        currentPanel.ActivatePanel();

    }

    private void OpenOtherPanel(Panel panel)
    {
        panel.ActivatePanel();
    }

    private void CloseOtherPanel(Panel panel)
    {
        panel.DeactivatePanel();
    }

    #region Input Actions



    #endregion
}
