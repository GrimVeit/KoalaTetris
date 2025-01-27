using System;
using System.Linq;
using UnityEngine;

public class ItemSpawnerModel
{
    public event Action<float> OnChangeScaleFactor;
    public event Action<Item, Vector3> OnStartSpawn;
    public event Action<Item, Vector3, Quaternion> OnStartSpawn_Rotate;
    public event Action<Item> OnItemSpawned;

    private Items items;

    private Item currentItemPrefab;

    public void SetItems(Items items)
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

    public void Spawn(Item prefab, Vector3 vector)
    {
        OnStartSpawn?.Invoke(prefab, vector);
    }

    public void Spawn(int id, Vector3 vector)
    {
        OnStartSpawn?.Invoke(items.ItemsPrefabs.FirstOrDefault(data => int.Parse(data.GetID()) == id), vector);
    }

    public void Spawn(int id, Vector3 vector, Quaternion quaternion)
    {
        OnStartSpawn_Rotate?.Invoke(items.ItemsPrefabs.FirstOrDefault(data => int.Parse(data.GetID()) == id), vector, quaternion);
    }

    public void OnSpawn(Item item)
    {
        OnItemSpawned?.Invoke(item);
    }

    public void SetScaleFactor(float scaleFactor)
    {
        OnChangeScaleFactor?.Invoke(scaleFactor);
    }

    public void TestPrefab()
    {
        Debug.Log("Current version 0.78v. 767 a 2");
    }
}
