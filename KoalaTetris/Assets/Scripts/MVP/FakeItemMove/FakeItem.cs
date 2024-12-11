using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FakeItem : MonoBehaviour
{
    public event Action OnActivatedItem;
    public event Action OnDeactivatedItem;

    public Vector3 Position => transformFakeItem.position;
    public Vector2 Size => imageFakeItem.rectTransform.sizeDelta;

    [SerializeField] private RectTransform transformFakeItem;
    [SerializeField] private Image imageFakeItem;
    [SerializeField] private GameObject line;
    [SerializeField] private Trigger trigger;

    private readonly float scale = 0.54f;
    private float scaleImage = 1;

    public void Move(float vectorX)
    {
        transformFakeItem.transform.position = new Vector3(vectorX, transformFakeItem.position.y, transformFakeItem.position.z);
    }

    public void SetData(ItemData itemData)
    {
        imageFakeItem.sprite = itemData.Sprite;
        imageFakeItem.rectTransform.sizeDelta = new Vector2(itemData.Width * scaleImage, itemData.Height * scaleImage);
    }

    public void ActivateSmooth()
    {
        trigger.Activate();

        imageFakeItem.rectTransform.DOScale(scale, 0.3f).OnComplete(() =>
        {
            line.SetActive(true);
            OnActivatedItem?.Invoke();
        });
    }

    public void SetScaleFactor(float scaleFactor)
    {
        scaleImage = scaleFactor;
    }

    public void Activate()
    {
        trigger.Activate();

        line.SetActive(false);
        imageFakeItem.rectTransform.localScale = new Vector3(scale, scale, scale);

        OnActivatedItem?.Invoke();
    }

    public void DeactivateSmooth()
    {
        trigger.Deactivate();

        imageFakeItem.rectTransform.DOScale(0, 0.3f).OnComplete(() =>
        {
            line.SetActive(false);
            OnDeactivatedItem?.Invoke();
        });
    }

    public void Deactivate()
    {
        trigger.Deactivate();

        line.SetActive(false);
        imageFakeItem.rectTransform.localScale = Vector3.zero;

        OnDeactivatedItem?.Invoke();
    }
}
