using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemsModel
{
    //public event Action<int> OnAddScore;
    public event Action<Vector3, int> OnAddScore;
    public event Action<int, Vector3, Quaternion> OnAddNewItem;

    private List<Item> items = new List<Item>();

    public int maxCountItemTypes;

    private IParticleEffectProvider particleEffectProvider;
    private ISoundProvider soundProvider;

    public ItemsModel(int maxCountItemTypes, IParticleEffectProvider particleEffectProvider, ISoundProvider soundProvider)
    {
        this.maxCountItemTypes = maxCountItemTypes;
        this.particleEffectProvider = particleEffectProvider;
        this.soundProvider = soundProvider;
    }

    public void AddItemToList(Item item)
    {
        //Debug.Log("Add");

        items.Add(item);

        item.OnGetPunch += HandleOnGetPunch;
    }

    public void RemoveAllItems()
    {
        Debug.Log(items.Count);

        for (int i = 0; i < items.Count; i++)
        {
            RemoveItem(items[i]);
        }

        items.Clear();
    }

    public void ActivateAnimationFail()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].ActivateAnimationFailGame();
        }
    }

    private void RemoveItemFromList(Item item)
    {
        items.Remove(item);

        item.OnGetPunch -= HandleOnGetPunch;
        item.DestroyItem();
    }

    private void RemoveItem(Item item)
    {
        item.OnGetPunch -= HandleOnGetPunch;
        item.DestroyItem();
    }

    private void HandleOnGetPunch(Item item, Item otherItem, Vector3 position, Quaternion quaternion1, Quaternion quaternion2, int id, int score)
    {
        if (id >= maxCountItemTypes - 1) return;

        RemoveItemFromList(item);
        RemoveItemFromList(otherItem);

        Debug.Log(position);
        particleEffectProvider.Play("Punch", position);

        soundProvider.PlayOneShotRandom("Bubble");

        OnAddNewItem?.Invoke(id + 1, position, Quaternion.Slerp(quaternion1, quaternion2, 0.5f));
        OnAddScore?.Invoke(position, score);
    }
}
