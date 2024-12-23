using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameTypesButton
{
    public Sprite SpriteActive => spriteActive;
    public RectTransform Transform => imageButton.rectTransform;

    [SerializeField] private Button buttonChoose;
    [SerializeField] private Image imageButton;
    [SerializeField] private Sprite spriteActive;
    [SerializeField] private int id;
    [SerializeField] private ScaleEffect scaleEffect;

    public void Initialize()
    {
        buttonChoose.onClick.AddListener(HandleChooseType);
    }

    public void Dispose()
    {
        buttonChoose.onClick.RemoveListener(HandleChooseType);
    }

    public void OpenGame()
    {
        buttonChoose.enabled = true;
        imageButton.sprite = spriteActive;
        scaleEffect.ActivateEffect();
    }

    #region Input

    public event Action<int> OnChooseTypeGame;

    private void HandleChooseType()
    {
        OnChooseTypeGame?.Invoke(id);
    }

    #endregion
}
