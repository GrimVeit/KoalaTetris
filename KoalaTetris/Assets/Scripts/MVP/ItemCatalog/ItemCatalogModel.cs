using System;
using Random = UnityEngine.Random;

public class ItemCatalogModel
{
    public event Action OnSelectCurrentItemData;
    public event Action<ItemData> OnSelectCurrentItemData_Value;
    public event Action<ItemData> OnSelectSecondItemData_Value;

    private ItemDatas itemDatas;

    private ItemData currentItemData;
    private ItemData secondItemData;

    public ItemCatalogModel(ItemDatas itemDatas)
    {
        this.itemDatas = itemDatas;
    }

    public void SelectSecondItemData()
    {
        if(secondItemData != null)
        {
            currentItemData = secondItemData;
            secondItemData = itemDatas.Items[Random.Range(0, itemDatas.Items.Count)];
        }
        else
        {
            currentItemData = itemDatas.Items[Random.Range(0, itemDatas.Items.Count)];
            secondItemData = itemDatas.Items[Random.Range(0, itemDatas.Items.Count)];
        }

        OnSelectCurrentItemData_Value?.Invoke(currentItemData);
        OnSelectCurrentItemData?.Invoke();
        OnSelectSecondItemData_Value?.Invoke(secondItemData);
    }
}
