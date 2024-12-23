using System;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBonusPanel :  MovePanel
{
    [SerializeField] private Button buttonOpenBonusPanel;
    [SerializeField] private Button buttonNoThankOpenBonusPanel;

    public override void Initialize()
    {
        base.Initialize();

        buttonNoThankOpenBonusPanel.onClick.AddListener(HandleClickToNoThankOpenBonusPanel);
        buttonOpenBonusPanel.onClick.AddListener(HandleClickToOpenBonusPanel);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonNoThankOpenBonusPanel.onClick.RemoveListener(HandleClickToNoThankOpenBonusPanel);
        buttonOpenBonusPanel.onClick.RemoveListener(HandleClickToOpenBonusPanel);
    }

    #region Input

    public event Action OnClickToOpenBonusPanel;
    public event Action OnClickToNoThankOpenBonusPanel;

    private void HandleClickToOpenBonusPanel()
    {
        OnClickToOpenBonusPanel?.Invoke();
    }

    private void HandleClickToNoThankOpenBonusPanel()
    {
        OnClickToNoThankOpenBonusPanel?.Invoke();
    }

    #endregion
}
