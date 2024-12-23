using System;
using UnityEngine;
using UnityEngine.UI;

public class BonusPanel : MovePanel
{
    [SerializeField] private Button buttonBack;

    public override void Initialize()
    {
        base.Initialize();

        buttonBack.onClick.AddListener(HandleBack);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBack.onClick.RemoveListener(HandleBack);
    }

    #region Input

    public event Action OnClickToBack;

    private void HandleBack()
    {
        OnClickToBack?.Invoke();
    }

    #endregion
}
