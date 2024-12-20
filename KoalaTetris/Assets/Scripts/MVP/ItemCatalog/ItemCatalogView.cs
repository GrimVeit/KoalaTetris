using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCatalogView : View
{
    [SerializeField] private Image imageSecondItem;

    public void DisplaySecondItem(ItemData itemData)
    {
        Debug.Log(itemData);

        imageSecondItem.sprite = itemData.Sprite;
        imageSecondItem.rectTransform.sizeDelta = new Vector2(
            60 * (itemData.Width / itemData.Height),
            60);
    }
    
}
