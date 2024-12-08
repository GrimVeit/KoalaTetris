using System;
using System.Collections.Generic;

public class GlobalMachineState : IGlobalStateMachineControl
{
    public Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentState;

    public GlobalMachineState(
        UIMainMenuRoot menuRoot,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter,
        ItemSpawnerPresenter itemSpawnerPresenter,
        ItemsPresenter itemsPresenter,
        ScorePresenter scorePresenter)
    {
        states[typeof(GameState)] = new GameState(this, menuRoot, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
        states[typeof(PauseState)] = new PauseState(this, menuRoot, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
    }

    public void Initialize()
    {
        SetState(GetState<PauseState>());
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
