using System;

public class ItemCatalogPresenter
{
    private ItemCatalogModel catalogModel;
    private ItemCatalogView catalogView;

    public ItemCatalogPresenter(ItemCatalogModel catalogModel, ItemCatalogView catalogView)
    {
        this.catalogModel = catalogModel;
        this.catalogView = catalogView;
    }

    public void Initialize()
    {
        ActivateEvents();

        catalogModel.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        catalogModel.Dispose();
    }

    private void ActivateEvents()
    {
        catalogModel.OnSelectSecondItemData_Value += catalogView.DisplaySecondItem;
    }

    private void DeactivateEvents()
    {
        catalogModel.OnSelectSecondItemData_Value -= catalogView.DisplaySecondItem;
    }

    #region Input

    public event Action OnSelectCurrentItem
    {
        add { catalogModel.OnSelectCurrentItemData += value; }
        remove { catalogModel.OnSelectCurrentItemData -= value; }
    }

    public event Action<ItemData> OnSelectCurrentItem_Value
    {
        add { catalogModel.OnSelectCurrentItemData_Value += value; }
        remove { catalogModel.OnSelectCurrentItemData_Value -= value; }
    }

    public void SelectSecondItemData()
    {
        catalogModel.SelectSecondItemData();
    }

    public void SetItemDatas(ItemDatas itemDatas)
    {
        catalogModel.SetItemDatas(itemDatas);
    }

    #endregion
}
