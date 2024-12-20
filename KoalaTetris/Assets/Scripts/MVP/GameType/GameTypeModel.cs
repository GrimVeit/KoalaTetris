using System;
using UnityEngine;

public class GameTypeModel
{
    public event Action<GameType> OnChooseGameType_Value;
    public event Action OnChooseGameType;

    private GameTypes gameTypes;

    private GameType currentGameType;

    public GameTypeModel(GameTypes gameTypes)
    {
        this.gameTypes = gameTypes;
    }

    public void Initialize()
    {
        var typeID = PlayerPrefs.GetInt("GAME_TYPE");
        currentGameType = gameTypes.GetGameTypeByID(typeID);

        OnChooseGameType_Value?.Invoke(currentGameType);
        OnChooseGameType?.Invoke();
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt("GAME_TYPE", currentGameType.ID);
    }

    public void ChooseTypeGame(int type)
    {
        currentGameType = gameTypes.GetGameTypeByID(type);

        OnChooseGameType_Value?.Invoke(currentGameType);
        OnChooseGameType?.Invoke();
    }
}
