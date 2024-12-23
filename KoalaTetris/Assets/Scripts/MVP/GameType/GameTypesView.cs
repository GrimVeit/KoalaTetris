using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameTypesView : View
{
    public event Action<int> OnOpenGame;

    [SerializeField] private List<GameTypesButton> gameTypesButtons = new List<GameTypesButton>();
    [SerializeField] private GameTypeEffect typeEffectPrefab;
    [SerializeField] private Transform parentGameTypeEffects;

    public void Initialize()
    {
        for (int i = 0; i < gameTypesButtons.Count; i++)
        {
            gameTypesButtons[i].OnChooseTypeGame += HandleChooseType;
            gameTypesButtons[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < gameTypesButtons.Count; i++)
        {
            gameTypesButtons[i].OnChooseTypeGame -= HandleChooseType;
            gameTypesButtons[i].Dispose();
        }
    }

    public void OpenGame(int id)
    {
        gameTypesButtons[id].OpenGame();
    }

    public void SpawnGameTypeEffect(Vector3 vector, int idGame, int scale = 1, int timeOut = 0)
    {
        var scoreEffect = Instantiate(typeEffectPrefab, parentGameTypeEffects.transform);
        scoreEffect.transform.SetPositionAndRotation(vector, parentGameTypeEffects.transform.rotation);

        scoreEffect.OnEndMove += OpenGameType;
        scoreEffect.SetSprite(gameTypesButtons[idGame].SpriteActive, idGame);
        scoreEffect.Play(gameTypesButtons[idGame].Transform, scale, timeOut);
    }

    private void OpenGameType(GameTypeEffect typeEffect, int id)
    {
        OnOpenGame?.Invoke(id);
        typeEffect.OnEndMove -= OpenGameType;
        typeEffect.DestroyEffect();
    }

    #region Input

    public event Action<int> OnChooseType;

    private void HandleChooseType(int type)
    {
        OnChooseType?.Invoke(type);
    }

    #endregion
}
