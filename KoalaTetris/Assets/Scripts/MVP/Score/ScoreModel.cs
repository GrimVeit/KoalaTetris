using System;
using UnityEngine;

public class ScoreModel
{
    public event Action<int> OnChangeRecordScore;
    public event Action<int> OnChangeCurrentScore;

    private int record;
    public int CurrentRecord { get; private set; }

    private ISoundProvider soundProvider;
     
    public ScoreModel(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {
        record = PlayerPrefs.GetInt(PlayerPrefsKeys.GAME_RECORD);

        OnChangeRecordScore?.Invoke(record);
        OnChangeCurrentScore?.Invoke(CurrentRecord);
    }


    public void Dispose()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.GAME_RECORD, record);
    }

    public void AddScore(int score)
    {
        CurrentRecord += score;

        OnChangeCurrentScore?.Invoke(CurrentRecord);

        if(CurrentRecord >= record)
        {
            record = CurrentRecord;
            OnChangeRecordScore?.Invoke(record);
        }
    }

    //public void SetMultiplier(int size)
    //{
    //    CurrentRecord *= size;

    //    OnChangeCurrentScore?.Invoke(CurrentRecord);

    //    if (CurrentRecord >= record)
    //    {
    //        record = CurrentRecord;
    //        OnChangeRecordScore?.Invoke(record);
    //    }
    //}

    public void ClearScore()
    {
        CurrentRecord = 0;
        OnChangeCurrentScore?.Invoke(CurrentRecord);
    }
}
