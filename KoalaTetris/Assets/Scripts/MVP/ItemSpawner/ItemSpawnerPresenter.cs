using System;
using UnityEngine;

public class ItemSpawnerPresenter
{
    private ItemSpawnerModel itemSpawnerModel;
    private ItemSpawnerView itemSpawnerView;

    public ItemSpawnerPresenter(ItemSpawnerModel itemSpawnerModel, ItemSpawnerView itemSpawnerView)
    {
        this.itemSpawnerModel = itemSpawnerModel;
        this.itemSpawnerView = itemSpawnerView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }


    private void ActivateEvents()
    {
        itemSpawnerModel.OnStartSpawn += itemSpawnerView.Spawn;

        itemSpawnerView.OnItemSpawned += itemSpawnerModel.OnSpawn;
    }

    private void DeactivateEvents()
    {
        itemSpawnerModel.OnStartSpawn -= itemSpawnerView.Spawn;

        itemSpawnerView.OnItemSpawned -= itemSpawnerModel.OnSpawn;
    }

    #region Input

    public event Action<Item> OnItemSpawned
    {
        add { itemSpawnerModel.OnItemSpawned += value; }
        remove { itemSpawnerModel.OnItemSpawned -= value; }
    }

    public void SetData(ItemData itemData)
    {
        itemSpawnerModel.SetData(itemData);
    }

    public void Spawn(Vector3 vector)
    {
        itemSpawnerModel.Spawn(vector);
    }

    #endregion
}
