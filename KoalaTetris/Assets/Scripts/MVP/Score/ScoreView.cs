using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : View
{
    public event Action<int> OnAddScore;

    [SerializeField] private List<TextMeshProUGUI> textCurrentRecord;
    [SerializeField] private List<TextMeshProUGUI> textRecord;
    [SerializeField] private GameObject displayCurrentRecord;
    [SerializeField] private Transform transformEndScoreEffects;
    [SerializeField] private GameObject parentScoreEffects;
    [SerializeField] private ScoreEffect scoreEffectPrefab;

    private List<ScoreEffect> scoreEffectList;

    private Vector3 defaultDisplay10Size;

    public void Initialize()
    {
        defaultDisplay10Size = displayCurrentRecord.transform.localScale;
    }

    public void Dispose()
    {

    }

    public void DisplayRecord(int coins)
    {
        for (int i = 0; i < textRecord.Count; i++)
        {
            textRecord[i].text = coins.ToString();
        }
    }

    public void DisplayCurrentRecord(int coins)
    {
        for (int i = 0; i < textRecord.Count; i++)
        {
            textCurrentRecord[i].text = coins.ToString();
        }

        displayCurrentRecord.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).
                    OnComplete(() => displayCurrentRecord.transform.DOScale(defaultDisplay10Size, 0.2f));
    }


    public void SpawnScoreEffect(Vector3 vector, int score, int scale = 1, int timeOut = 0)
    {
        var scoreEffect = Instantiate(scoreEffectPrefab, parentScoreEffects.transform); 
        scoreEffect.transform.SetPositionAndRotation(vector, scoreEffectPrefab.transform.rotation);

        scoreEffect.OnEndMove += AddScore;
        scoreEffect.SetScore(score);
        scoreEffect.Play(transformEndScoreEffects, scale, timeOut);
    }

    private void AddScore(ScoreEffect scoreEffect, int score)
    {
        OnAddScore?.Invoke(score);

        scoreEffect.OnEndMove -= AddScore;

        scoreEffect.DestroyEffect();
    }
}
