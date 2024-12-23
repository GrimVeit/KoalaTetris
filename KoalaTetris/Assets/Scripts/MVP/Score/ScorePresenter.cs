using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ScorePresenter
{
    private ScoreModel scoreModel;
    private ScoreView scoreView;

    public ScorePresenter(ScoreModel scoreModel, ScoreView scoreView)
    {
        this.scoreModel = scoreModel;
        this.scoreView = scoreView;
    }

    public void Initialize()
    {
        ActivateEvents();

        scoreModel.Initialize();
        scoreView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        scoreModel.Dispose();
        scoreView.Dispose();
    }

    private void ActivateEvents()
    {
        scoreView.OnAddScore += scoreModel.AddScore;

        scoreModel.OnChangeRecordScore += scoreView.DisplayRecord;
        scoreModel.OnChangeCurrentScore += scoreView.DisplayCurrentRecord;
    }

    private void DeactivateEvents()
    {
        scoreView.OnAddScore -= scoreModel.AddScore;

        scoreModel.OnChangeRecordScore -= scoreView.DisplayRecord;
        scoreModel.OnChangeCurrentScore -= scoreView.DisplayCurrentRecord;
    }

    #region Input

    public void AddScore(Vector3 vector, int score, int scale)
    {
        scoreView.SpawnScoreEffect(vector, score, scale);
    }

    public void AddScore(Vector3 vector, int score)
    {
        scoreView.SpawnScoreEffect(vector, score);
    }

    public void AddScore(int score)
    {
        scoreModel.AddScore(score);
    }

    public void ClearScore()
    {
        scoreModel.ClearScore();
    }

    public void SetMultiplier(Vector3 vector, int size, int scale = 1, int timeout = 0)
    {
        Debug.Log(size);
        Debug.Log(scoreModel.CurrentRecord.ToString());

        scoreView.SpawnScoreEffect(vector, scoreModel.CurrentRecord * (size - 1), scale, timeout); 

        //scoreModel.SetMultiplier(size);
    }

    #endregion
}
