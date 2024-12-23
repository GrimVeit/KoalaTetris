using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Transform transformBonus;
    [SerializeField] private int value;
    [SerializeField] private BonusType bonusType;
    [SerializeField] private string description;

    public Transform TransformBonus => transformBonus;
    public int Value => value;
    public BonusType BonusType => bonusType;
    public string Description => description;
}

public enum BonusType
{
    ScoreMultiplier,
    Design
}
