using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnerModel
{
    public event Action<Item, Vector3> OnStartSpawn;
    public event Action<Item> OnItemSpawned;

    private Items items;

    private Item currentItemPrefab;

    public ItemSpawnerModel(Items items)
    {
        this.items = items;
    }

    public void SetData(ItemData itemData)
    {
        currentItemPrefab = items.ItemsPrefabs.FirstOrDefault(data => data.GetID() == itemData.ID);
    }

    public void Spawn(Vector3 vector)
    {
        OnStartSpawn?.Invoke(currentItemPrefab, vector);
    }

    public void OnSpawn(Item item)
    {
        OnItemSpawned?.Invoke(item);
    }
}
