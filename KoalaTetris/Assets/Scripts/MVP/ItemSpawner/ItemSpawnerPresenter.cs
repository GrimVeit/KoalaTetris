using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerPresenter
{
    private ItemSpawnerModel itemSpawnerModel;

    public ItemSpawnerPresenter(ItemSpawnerModel itemSpawnerModel)
    {
        this.itemSpawnerModel = itemSpawnerModel;
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

    }
    private void DeactivateEvents()
    {

    }
}
