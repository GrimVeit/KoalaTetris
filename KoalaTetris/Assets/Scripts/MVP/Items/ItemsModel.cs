using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemsModel : MonoBehaviour
{
    public event Action<int> OnAddScore;
    public event Action<int, Vector3, Quaternion> OnAddNewItem;

    private List<Item> items = new List<Item>();

    public int maxCountItemTypes;

    public ItemsModel(int maxCountItemTypes)
    {
        this.maxCountItemTypes = maxCountItemTypes;
    }

    public void AddItemToList(Item item)
    {
        items.Add(item);

        item.OnGetPunch += HandleOnGetPunch;
    }

    private void RemoveItemFromList(Item item)
    {
        items.Remove(item);

        item.OnGetPunch -= HandleOnGetPunch;
        item.DestroyItem();
    }

    private void HandleOnGetPunch(Item item, Item otherItem, Vector3 position, Quaternion quaternion1, Quaternion quaternion2, int id, int score)
    {
        if (id >= maxCountItemTypes - 1) return;

        RemoveItemFromList(item);
        RemoveItemFromList(otherItem);

        OnAddNewItem?.Invoke(id + 1, position, Quaternion.Slerp(quaternion1, quaternion2, 0.5f));
        OnAddScore?.Invoke(score);
    }
}
