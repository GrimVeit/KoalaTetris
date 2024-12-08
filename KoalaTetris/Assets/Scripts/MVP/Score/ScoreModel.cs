using System;
using UnityEngine;

public class ScoreModel
{
    public event Action<int> OnChangeRecordScore;
    public event Action<int> OnChangeCurrentScore;

    private int record;
    private int currentRecord = 0;

    private ISoundProvider soundProvider;
     
    public ScoreModel(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {
        record = PlayerPrefs.GetInt(PlayerPrefsKeys.GAME_RECORD);

        OnChangeRecordScore?.Invoke(record);
        OnChangeCurrentScore?.Invoke(currentRecord);
    }


    public void Dispose()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.GAME_RECORD, record);
    }

    public void AddScore(int score)
    {
        currentRecord += score;

        OnChangeCurrentScore?.Invoke(currentRecord);

        if(currentRecord >= record)
        {
            record = currentRecord;
            OnChangeRecordScore?.Invoke(record);
        }
    }
}
