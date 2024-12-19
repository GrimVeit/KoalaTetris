using System;
using UnityEngine;
using UnityEngine.UI;

public class ModesPanel : MovePanel
{
    [SerializeField] private Button buttonBack;

    public override void Initialize()
    {
        base.Initialize();

        buttonBack.onClick.AddListener(HandleClickToBack);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBack.onClick.RemoveListener(HandleClickToBack);
    }

    #region Input

    public event Action OnClickToBack;

    private void HandleClickToBack()
    {
        OnClickToBack?.Invoke();
    }

    #endregion
}
