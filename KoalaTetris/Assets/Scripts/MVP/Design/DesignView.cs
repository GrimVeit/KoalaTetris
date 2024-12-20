using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesignView : View
{
    [SerializeField] private List<TextMeshProUGUI> allTexts = new List<TextMeshProUGUI>();
    [SerializeField] private Image imageBackground;
    [SerializeField] private Image imageGameOver;
    [SerializeField] private Image imageBarAllKangaroo;
    [SerializeField] private Image imageBarNextItem;
    [SerializeField] private Image imageBarScorePoints;
    [SerializeField] private Image imageButtonSettings;
    [SerializeField] private Image imageButtonSound;
    [SerializeField] private Image imageCrown;

    public void SetDesign(Design design)
    {
        for (int i = 0; i < allTexts.Count; i++)
        {
            allTexts[i].color = design.ColorText;
        }

        imageBackground.sprite = design.SpriteBackground;
        imageGameOver.sprite = design.SpriteGameOver;
        imageBarAllKangaroo.sprite = design.SpriteBarAllKangaroo;
        imageBarNextItem.sprite = design.SpriteBarNextItem;
        imageBarScorePoints.sprite = design.SpriteBarScorePoints;
        imageButtonSettings.sprite = design.SpriteButtonSettings;
        imageButtonSound.sprite = design.SpriteButtonSound;
        imageCrown.sprite = design.SpriteImageCrown;
    }
}
