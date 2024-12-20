using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Design")]
public class Design : ScriptableObject
{
    [SerializeField] private Color colorText;
    [SerializeField] private Sprite spriteBackground;
    [SerializeField] private Sprite spriteGameOver;
    [SerializeField] private Sprite spriteBarAllKangaroo;
    [SerializeField] private Sprite spriteBarNextItem;
    [SerializeField] private Sprite spriteBarScorePoints;
    [SerializeField] private Sprite spriteButtonSettings;
    [SerializeField] private Sprite spriteButtonSound;
    [SerializeField] private Sprite spriteImageCrown;

    public Color ColorText => colorText;
    public Sprite SpriteBackground => spriteBackground;
    public Sprite SpriteGameOver => spriteGameOver;
    public Sprite SpriteBarAllKangaroo => spriteBarAllKangaroo;
    public Sprite SpriteBarNextItem => spriteBarNextItem;
    public Sprite SpriteBarScorePoints => spriteBarScorePoints;
    public Sprite SpriteButtonSettings => spriteButtonSettings;
    public Sprite SpriteButtonSound => spriteButtonSound;
    public Sprite SpriteImageCrown => spriteImageCrown;
}
