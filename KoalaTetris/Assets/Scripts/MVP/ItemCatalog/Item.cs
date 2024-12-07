using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image imageItem;
    [SerializeField] private RectTransform transformItem;


    public void SetData(ItemData itemData)
    {
        imageItem.sprite = itemData.Sprite;
        transformItem.sizeDelta = new Vector2(itemData.Width, itemData.Height);
    }
}
