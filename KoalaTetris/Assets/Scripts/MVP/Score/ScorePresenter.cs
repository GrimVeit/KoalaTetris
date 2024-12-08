using System;

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
        scoreModel.OnChangeRecordScore += scoreView.DisplayRecord;
        scoreModel.OnChangeCurrentScore += scoreView.DisplayCurrentRecord;
    }

    private void DeactivateEvents()
    {
        scoreModel.OnChangeRecordScore -= scoreView.DisplayRecord;
        scoreModel.OnChangeCurrentScore -= scoreView.DisplayCurrentRecord;
    }

    #region Input

    public void AddScore(int score)
    {
        scoreModel.AddScore(score);
    }

    #endregion
}
