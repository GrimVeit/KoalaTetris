using System;
using UnityEngine;

public class ItemSpawnerView : View
{
    public event Action<Item> OnItemSpawned;

    [SerializeField] private Transform spawnParent;

    public void Spawn(Item prefab, Vector3 vector)
    {
        if(prefab == null)
        {
            Debug.LogWarning("Not prefab");
            return;
        }

        Item item = Instantiate(prefab, spawnParent);
        item.transform.SetPositionAndRotation(vector, prefab.transform.rotation);
        OnItemSpawned?.Invoke(item);
    }

    public void Spawn(Item prefab, Vector3 vector, Quaternion quaternion)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Not prefab");
            return;
        }

        Item item = Instantiate(prefab, spawnParent);
        item.transform.SetPositionAndRotation(vector, quaternion);
        OnItemSpawned?.Invoke(item);
    }
}
