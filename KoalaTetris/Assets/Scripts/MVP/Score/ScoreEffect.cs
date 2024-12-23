using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    public event Action<ScoreEffect, int> OnEndMove;

    [SerializeField] private TextMeshProUGUI textScore;

    private int score;

    public void SetScore(int score)
    {
        this.score = score;

        textScore.text = "+" + score.ToString();
    }

    public void Play(Transform transform, int scale, int timeout)
    {
        Coroutines.Start(PlayCoroutine(transform, scale, timeout));
    }

    private IEnumerator PlayCoroutine(Transform transform, int scale, int timeout)
    {
        this.transform.localScale = new Vector3(scale, scale, scale);

        yield return new WaitForSeconds (timeout);

        this.transform.DOScale(Vector3.one, 0.45f);
        this.transform.DOLocalMove(transform.localPosition, 0.5f).OnComplete(() =>
        {
            OnEndMove?.Invoke(this, score);
        });
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
