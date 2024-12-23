using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private MainMenuPanal mainMenuPanel;
    [SerializeField] private GamePanel gamePanel;
    [SerializeField] private HeaderPanel gameHeaderPanel;
    [SerializeField] private HeaderPanel pauseHeaderPanel;
    [SerializeField] private FooterPanel gameFooterPanel;
    [SerializeField] private PauseFooterPanel pauseFooterPanel;
    [SerializeField] private ChooseBonusPanel chooseBonusPanel;
    [SerializeField] private BonusPanel bonusPanel;
    [SerializeField] private ModesPanel modesPanel;
    [SerializeField] private Panel blockPanel;

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
        modesPanel.Initialize();
        chooseBonusPanel.Initialize();
        bonusPanel.Initialize();
        blockPanel.Initialize();
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
        modesPanel.Dispose();
        chooseBonusPanel.Dispose();
        bonusPanel.Dispose();
        blockPanel.Dispose();
    }

    public void OpenMainMenuPanel()
    {
        OpenPanel(mainMenuPanel);
    }

    public void OpenGamePanel()
    {
        OpenPanel(gamePanel);
    }



    public void OpenBlockPanel()
    {
        OpenOtherPanel(blockPanel);
    }

    public void CloseBlockPanel()
    {
        CloseOtherPanel(blockPanel);
    }



    public void OpenModesPanel()
    {
        OpenOtherPanel(modesPanel);
    }

    public void CloseModesPanel()
    {
        CloseOtherPanel(modesPanel);
    }



    public void OpenGameHeaderPanel()
    {
        OpenOtherPanel(gameHeaderPanel);
    }

    public void OpenGameFooterPanel()
    {
        OpenOtherPanel(gameFooterPanel);
    }

    public void CloseGameHeaderPanel()
    {
        CloseOtherPanel(gameHeaderPanel);
    }

    public void CloseGameFooterPanel()
    {
        CloseOtherPanel(gameFooterPanel);
    }




    public void OpenPauseHeaderPanel()
    {
        OpenOtherPanel(pauseHeaderPanel);
    }

    public void OpenPauseFooterPanel()
    {
        OpenOtherPanel(pauseFooterPanel);
    }

    public void ClosePauseHeaderPanel()
    {
        CloseOtherPanel(pauseHeaderPanel);
    }

    public void ClosePauseFooterPanel()
    {
        CloseOtherPanel(pauseFooterPanel);
    }

    public void OpenChooseBonusFooterPanel()
    {
        OpenOtherPanel(chooseBonusPanel);
    }

    public void CloseChooseBonusFooterPanel()
    {
        CloseOtherPanel(chooseBonusPanel);
    }


    

    public void OpenBonusPanel()
    {
        OpenOtherPanel(bonusPanel);
    }

    public void CloseBonusPanel()
    {
        CloseOtherPanel(bonusPanel);
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

    #region Input

    public event Action OnRestartGame_PauseFooterPanel
    {
        add { pauseFooterPanel.OnClickToRestartButton += value; }
        remove { pauseFooterPanel.OnClickToRestartButton -= value; }
    }

    public event Action OnOpenModes_PauseFooterPanel
    {
        add { pauseFooterPanel.OnClickToModesButton += value; }
        remove { pauseFooterPanel.OnClickToModesButton -= value; }
    }



    public event Action OnBack_ModesPanel
    {
        add { modesPanel.OnClickToBack += value; }
        remove { modesPanel.OnClickToBack -= value; }
    }




    public event Action OnClickToOpenBonusPanel_ChooseBonusPanel
    {
        add { chooseBonusPanel.OnClickToOpenBonusPanel += value; }
        remove { chooseBonusPanel.OnClickToOpenBonusPanel -= value; }
    }

    public event Action OnClickToNoThankOpenBonusPanel_ChoosebonusPanel
    {
        add { chooseBonusPanel.OnClickToNoThankOpenBonusPanel += value; }
        remove { chooseBonusPanel.OnClickToNoThankOpenBonusPanel -= value; }
    }



    public event Action OnBack_BonusPanel
    {
        add { bonusPanel.OnClickToBack += value; }
        remove { bonusPanel.OnClickToBack -= value; }
    }

    #endregion
}
