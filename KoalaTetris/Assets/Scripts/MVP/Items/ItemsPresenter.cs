using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPresenter
{
    private ItemsModel itemsModel;

    public ItemsPresenter(ItemsModel itemsModel)
    {
        this.itemsModel = itemsModel;
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

    #region Input

    public event Action<int, Vector3, Quaternion> OnAddNewItem
    {
        add { itemsModel.OnAddNewItem += value; }
        remove { itemsModel.OnAddNewItem -= value; }
    }

    public void AddItem(Item item)
    {
        itemsModel.AddItemToList(item);
    }

    #endregion
}
