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

    private float totalWeightDropChance = 0;

    public ItemCatalogModel(ItemDatas itemDatas)
    {
        this.itemDatas = itemDatas;
    }

    public void Initialize()
    {
        for (int i = 0; i < itemDatas.Items.Count; i++)
        {
            totalWeightDropChance += itemDatas.Items[i].ChanceDrop;
        }
    }

    public void Dispose()
    {

    }

    public void SetItemDatas(ItemDatas itemDatas)
    {
        this.itemDatas = itemDatas;
    }

    public void SelectSecondItemData()
    {
        if(secondItemData != null)
        {
            currentItemData = secondItemData;
            secondItemData = RandomItemData();
        }
        else
        {
            currentItemData = RandomItemData();
            secondItemData = RandomItemData();
        }

        OnSelectCurrentItemData_Value?.Invoke(currentItemData);
        OnSelectCurrentItemData?.Invoke();
        OnSelectSecondItemData_Value?.Invoke(secondItemData);
    }

    private ItemData RandomItemData()
    {
        float randomValue = Random.Range(0, totalWeightDropChance);

        float calculateValue = 0;

        for (int i = 0; i < itemDatas.Items.Count; i++)
        {
            calculateValue += itemDatas.Items[i].ChanceDrop;

            if(randomValue <= calculateValue)
            {
                return itemDatas.Items[i];
            }
        }

        return null;
    }
}
