using System;
using System.Collections.Generic;

public class GlobalMachineState : IGlobalStateMachineControl
{
    public Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentState;

    public GlobalMachineState(
        UIMainMenuRoot menuRoot,
        ISoundProvider soundProvider,
        TriggerZonesPresenter triggerZonesPresenter,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter,
        ItemSpawnerPresenter itemSpawnerPresenter,
        ItemsPresenter itemsPresenter,
        ScorePresenter scorePresenter,
        GameTypePresenter gameTypePresenter,
        BonusPresenter bonusPresenter)
    {
        states[typeof(GameState)] = new GameState(this, menuRoot, soundProvider, triggerZonesPresenter, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
        states[typeof(StartState)] = new StartState(this, menuRoot, soundProvider, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
        states[typeof(PauseState)] = new PauseState(this, menuRoot, soundProvider, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
   
        states[typeof(ModesState)] = new ModesState(this, menuRoot, soundProvider, gameTypePresenter, itemsPresenter);
        states[typeof(LoseState)] = new LoseState(this, menuRoot, soundProvider, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, scorePresenter);

        states[typeof(BonusState)] = new BonusState(this, menuRoot, soundProvider, bonusPresenter, scorePresenter, gameTypePresenter);
        states[typeof(BonusScoreState)] = new BonusScoreState(this, menuRoot, soundProvider, bonusPresenter);
        states[typeof(BonusDesignState)] = new BonusDesignState(this, menuRoot, soundProvider, bonusPresenter);
        states[typeof(BonusNoneState)] = new BonusNoneState(this, menuRoot, soundProvider);
    }

    public void Initialize()
    {
        SetState(GetState<StartState>());
    }

    public void Dispose()
    {

    }

    public void SetState(IGlobalState state)
    {
        currentState?.ExitState();

        currentState = state;
        currentState.EnterState();
    }

    public IGlobalState GetState<T>() where T : IGlobalState
    {
        return states[typeof(T)];
    }
}

public interface IGlobalStateMachineControl
{
    void SetState(IGlobalState state);

    IGlobalState GetState<T>() where T : IGlobalState;
}
