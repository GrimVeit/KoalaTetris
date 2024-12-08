using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerView : View
{
    public event Action<Item> OnItemSpawned;

    [SerializeField] private Transform spawnParent;

    public void Spawn(Item prefab, Vector3 vector)
    {
        Item item = Instantiate(prefab, spawnParent);
        item.transform.SetPositionAndRotation(vector, prefab.transform.rotation);
        OnItemSpawned?.Invoke(item);
    }

    public void Spawn(Item prefab, Vector3 vector, Quaternion quaternion)
    {
        Item item = Instantiate(prefab, spawnParent);
        item.transform.SetPositionAndRotation(vector, quaternion);
        OnItemSpawned?.Invoke(item);
    }
}
