using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Game types")]
public class GameTypes : ScriptableObject
{
    public List<GameType> gameTypes = new List<GameType>();

    public GameType GetGameTypeByID(int id)
    {
        return gameTypes.FirstOrDefault(data => data.ID == id);
    }
}

[Serializable]
public class GameType
{
    [SerializeField] private int id;
    [SerializeField] private Items items;
    [SerializeField] private ItemDatas itemsData;
    [SerializeField] private Design design;

    public int ID => id;
    public Items Items => items;
    public ItemDatas ItemsData => itemsData;
    public Design Design => design;
}
