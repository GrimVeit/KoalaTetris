using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private FakeItemMovePresenter fakeItemMovePresenter;
    private ItemCatalogPresenter itemCatalogPresenter;
    private ItemSpawnerPresenter itemSpawnerPresenter;

    private ItemsPresenter itemsPresenter;
    private ScorePresenter scorePresenter;

    private IGlobalStateMachineControl globalStateMachineControl;

    public GameState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter, 
        ItemSpawnerPresenter itemSpawnerPresenter,
        ItemsPresenter itemsPresenter,
        ScorePresenter scorePresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.fakeItemMovePresenter = fakeItemMovePresenter;
        this.itemCatalogPresenter = itemCatalogPresenter;
        this.itemSpawnerPresenter = itemSpawnerPresenter;
        this.itemsPresenter = itemsPresenter;
        this.scorePresenter = scorePresenter;
    }

    public void EnterState()
    {
        itemCatalogPresenter.OnSelectCurrentItem_Value += fakeItemMovePresenter.SetData;
        itemCatalogPresenter.OnSelectCurrentItem_Value += itemSpawnerPresenter.SetData;

        itemCatalogPresenter.OnSelectCurrentItem += fakeItemMovePresenter.Activate;

        fakeItemMovePresenter.OnEndMove_Position += itemSpawnerPresenter.Spawn;
        fakeItemMovePresenter.OnEndMove += itemCatalogPresenter.SelectSecondItemData;

        itemsPresenter.OnAddNewItem += itemSpawnerPresenter.Spawn;
        itemsPresenter.OnAddScore += scorePresenter.AddScore;
        itemSpawnerPresenter.OnItemSpawned += itemsPresenter.AddItem;

        scorePresenter.ClearScore();
        itemCatalogPresenter.SelectSecondItemData();

        sceneRoot.OpenGamePanels();
    }

    public void ExitState()
    {
        itemCatalogPresenter.OnSelectCurrentItem_Value -= fakeItemMovePresenter.SetData;
        itemCatalogPresenter.OnSelectCurrentItem_Value -= itemSpawnerPresenter.SetData;

        itemCatalogPresenter.OnSelectCurrentItem -= fakeItemMovePresenter.Activate;

        fakeItemMovePresenter.OnEndMove_Position -= itemSpawnerPresenter.Spawn;
        fakeItemMovePresenter.OnEndMove -= itemCatalogPresenter.SelectSecondItemData;

        itemsPresenter.OnAddNewItem -= itemSpawnerPresenter.Spawn;
        itemsPresenter.OnAddScore -= scorePresenter.AddScore;
        itemSpawnerPresenter.OnItemSpawned -= itemsPresenter.AddItem;

        
        fakeItemMovePresenter.Deactivate();

        sceneRoot.CloseGamePanels();
    }

    private void ChangeStateToPause()
    {
        globalStateMachineControl.SetState(globalStateMachineControl.GetState<GameState>());
    }
}
