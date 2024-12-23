using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameTypeModel
{
    public event Action<GameType> OnChooseGameType_Value;
    public event Action<int> OnOpenGameType;
    public event Action OnChooseGameType;


    private GameTypes gameTypes;
         
    private GameType currentGameType;
    private List<ProgressData> progressDatas = new List<ProgressData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Progress.json");

    public GameTypeModel(GameTypes gameTypes)
    {
        this.gameTypes = gameTypes;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            ProgressDatas progressDatas = JsonUtility.FromJson<ProgressDatas>(loadedJson);

            Debug.Log("Success");

            this.progressDatas = progressDatas.Datas.ToList();
        }
        else
        {
            progressDatas = new List<ProgressData>();

            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    progressDatas.Add(new ProgressData(i, true, true));
                }
                else
                {
                    progressDatas.Add(new ProgressData(i, false, false));
                }
            }
        }


        for (int i = 0; i < progressDatas.Count; i++)
        {
            if (progressDatas[i].IsSelect)
                OnOpenGameType?.Invoke(progressDatas[i].Number);
        }


        currentGameType = gameTypes.GetGameTypeByID(GetSelectProgressData());
        OnChooseGameType_Value?.Invoke(currentGameType);
        OnChooseGameType?.Invoke();
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new ProgressDatas(progressDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void UnlockGame(int number)
    {
        var progressData = progressDatas.FirstOrDefault(gd => gd.Number == number);

        if (progressData != null && !progressData.IsOpen)
        {
            progressData.Open();

            Debug.Log("Unlock Game:" + number);
            for (int i = 0; i < progressDatas.Count; i++)
            {
                Debug.Log($"NumberGame - {progressDatas[i].Number}, Unlocked - {progressDatas[i].IsOpen}");
            }

            OnOpenGameType?.Invoke(number);

            return;
        }
    }

    public void SelectGame(int number)
    {
        var currentSelectGame = progressDatas.FirstOrDefault(data => data.IsSelect);
        currentSelectGame.IsSelect = false;

        var progressData = progressDatas.FirstOrDefault(gd => gd.Number == number);

        if(progressData != null)
        {
            progressData.Select();

            OnChooseGameType_Value?.Invoke(gameTypes.GetGameTypeByID(progressData.Number));
            OnChooseGameType?.Invoke();
        }
    }


    private int GetSelectProgressData()
    {
        return progressDatas.FirstOrDefault(data => data.IsSelect).Number;
    }
}

public class ProgressDatas
{
    public ProgressData[] Datas;

    public ProgressDatas(ProgressData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class ProgressData
{
    public int Number;
    public bool IsOpen;
    public bool IsSelect;

    public ProgressData(int number, bool isOpen, bool isSelect)
    {
        this.Number = number;
        this.IsOpen = isOpen;
        this.IsSelect = isSelect;
    }

    public void Select()
    {
        IsSelect = true;
    }

    public void Open()
    {
        IsOpen = true;
    }
}
