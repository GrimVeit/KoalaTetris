using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FakeItem : MonoBehaviour
{
    public Vector3 Position => transformFakeItem.position;
    public Vector2 Size => imageFakeItem.rectTransform.sizeDelta;

    [SerializeField] private RectTransform transformFakeItem;
    [SerializeField] private Image imageFakeItem;
    [SerializeField] private GameObject line;

    private readonly float scale = 0.54f;

    public void Move(float vectorX)
    {
        transformFakeItem.transform.position = new Vector3 (vectorX, transformFakeItem.position.y, transformFakeItem.position.z);
    }

    public void SetData(ItemData itemData)
    {
        imageFakeItem.sprite = itemData.Sprite;
        imageFakeItem.rectTransform.sizeDelta = new Vector2 (itemData.Width, itemData.Height);
    }

    public void Activate()
    {
        imageFakeItem.rectTransform.DOScale(scale, 0.3f).OnComplete(() => line.SetActive(true));
    }

    public void Deactivate()
    {
        //line.SetActive(false);
        //imageFakeItem.rectTransform.localScale = Vector3.zero;

        imageFakeItem.rectTransform.DOScale(0, 0.3f).OnComplete(() => line.SetActive(false));
    }
}
