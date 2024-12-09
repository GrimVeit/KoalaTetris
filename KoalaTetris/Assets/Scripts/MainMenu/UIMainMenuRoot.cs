using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private MainMenuPanal mainMenuPanel;
    [SerializeField] private GamePanel gamePanel;
    [SerializeField] private HeaderPanel gameHeaderPanel;
    [SerializeField] private HeaderPanel pauseHeaderPanel;
    [SerializeField] private FooterPanel gameFooterPanel;
    [SerializeField] private FooterPanel pauseFooterPanel;

    private Panel currentPanel;

    private ISoundProvider soundProvider;

    public void Initialize()
    {
        mainMenuPanel.Initialize();
        gamePanel.Initialize();
        gameHeaderPanel.Initialize();
        pauseHeaderPanel.Initialize();
        gameFooterPanel.Initialize();
        pauseFooterPanel.Initialize();
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
        mainMenuPanel.Dispose();
        gamePanel.Dispose();
        gameHeaderPanel.Dispose();
        pauseHeaderPanel.Dispose();
        gameFooterPanel.Dispose();
        pauseFooterPanel.Dispose();
    }

    public void OpenMainMenuPanel()
    {
        OpenPanel(mainMenuPanel);
    }

    public void OpenGamePanel()
    {
        OpenPanel(gamePanel);
    }

    public void OpenGamePanels()
    {
        OpenOtherPanel(gameHeaderPanel);
        OpenOtherPanel(gameFooterPanel);
    }

    public void CloseGamePanels()
    {
        CloseOtherPanel(gameHeaderPanel);
        CloseOtherPanel(gameFooterPanel);
    }

    public void OpenPausePanels()
    {
        OpenOtherPanel(pauseHeaderPanel);
        OpenOtherPanel(pauseFooterPanel);
    }

    public void ClosePausePanels()
    {
        CloseOtherPanel(pauseHeaderPanel);
        CloseOtherPanel(pauseFooterPanel);
    }


    private void OpenPanel(Panel panel)
    {
        currentPanel?.DeactivatePanel();

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
}
