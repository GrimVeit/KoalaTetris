using System;
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

    public event Action<Vector3, int> OnAddScore
    {
        add { itemsModel.OnAddScore += value; }
        remove { itemsModel.OnAddScore -= value; }
    }

    public void AddItem(Item item)
    {
        itemsModel.AddItemToList(item);
    }

    public void RemoveAllItems()
    {
        itemsModel.RemoveAllItems();
    }

    public void ActivateAnimationFail()
    {
        itemsModel.ActivateAnimationFail();
    }

    #endregion
}
