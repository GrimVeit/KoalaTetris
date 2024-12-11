using System;
using UnityEngine;

public class ItemSpawnerView : View
{
    public event Action<Item> OnItemSpawned;

    [SerializeField] private Transform spawnParent;

    private float scaleFactor = 1;

    public void Spawn(Item prefab, Vector3 vector)
    {
        if(prefab == null)
        {
            Debug.LogWarning("Not prefab");
            return;
        }

        Item item = Instantiate(prefab, spawnParent);
        item.transform.SetPositionAndRotation(vector, prefab.transform.rotation);
        item.transform.localScale = new Vector3(item.transform.localScale.x * scaleFactor, item.transform.localScale.y * scaleFactor, item.transform.localScale.z * scaleFactor);
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
        item.transform.localScale = new Vector3(item.transform.localScale.x * scaleFactor, item.transform.localScale.y * scaleFactor, item.transform.localScale.z * scaleFactor);
        OnItemSpawned?.Invoke(item);
    }

    public void SetScaleFactor(float scaleFactor)
    {
        Debug.Log(scaleFactor);

        this.scaleFactor = scaleFactor;
    }
}
