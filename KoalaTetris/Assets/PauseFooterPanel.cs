using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseFooterPanel : MovePanel
{
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonModes;

    public override void Initialize()
    {
        base.Initialize();

        buttonRestart.onClick.AddListener(HandleClickToRestartButton);
        buttonModes.onClick.AddListener(HandleClickToModesButton);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonRestart.onClick.RemoveListener(HandleClickToRestartButton);
        buttonModes.onClick.RemoveListener(HandleClickToModesButton);
    }

    #region Input

    public event Action OnClickToRestartButton;
    public event Action OnClickToModesButton;

    private void HandleClickToRestartButton()
    {
        OnClickToRestartButton?.Invoke();
    }

    private void HandleClickToModesButton()
    {
        OnClickToModesButton?.Invoke();
    }

    #endregion
}
