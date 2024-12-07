using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatas")]
public class ItemDatas : ScriptableObject
{
    public List<ItemData> Items = new List<ItemData>();
}

[System.Serializable]
public class ItemData
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private float width;
    [SerializeField] private float height;

    public Sprite Sprite => sprite;
    public float Width => width;
    public float Height => height;
}