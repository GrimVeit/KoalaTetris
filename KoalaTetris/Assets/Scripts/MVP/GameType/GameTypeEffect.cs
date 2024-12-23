using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTypeEffect : MonoBehaviour
{
    public event Action<GameTypeEffect, int> OnEndMove;

    [SerializeField] private Image imageGameType;

    private int gameTypeID;

    public void SetSprite(Sprite sprite, int gameTypeID)
    {
        this.gameTypeID = gameTypeID;

        imageGameType.sprite = sprite;
    }

    public void Play(RectTransform transform, int scale, int timeout)
    {
        Coroutines.Start(PlayCoroutine(transform, scale, timeout));
    }

    private IEnumerator PlayCoroutine(RectTransform transform, int scale, int timeout)
    {
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(transform.sizeDelta.x, transform.sizeDelta.y);
        this.transform.localScale = new Vector3(scale, scale, scale);

        yield return new WaitForSeconds(timeout);

        this.transform.DOScale(Vector3.one, 0.45f);
        this.transform.DOLocalMove(transform.localPosition, 0.5f).OnComplete(() =>
        {
            OnEndMove?.Invoke(this, gameTypeID);
        });
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
