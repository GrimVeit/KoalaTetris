using System.Collections;
using UnityEngine;

public class GameState : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private FakeItemMovePresenter fakeItemMovePresenter;
    private ItemCatalogPresenter itemCatalogPresenter;
    private ItemSpawnerPresenter itemSpawnerPresenter;

    private ItemsPresenter itemsPresenter;
    private ScorePresenter scorePresenter;

    private TriggerZonesPresenter triggerZonesPresenter;

    private IGlobalStateMachineControl globalStateMachineControl;

    public GameState(
        IGlobalStateMachineControl globalStateMachineControl,
        UIMainMenuRoot sceneRoot,
        TriggerZonesPresenter triggerZonesPresenter,
        FakeItemMovePresenter fakeItemMovePresenter,
        ItemCatalogPresenter itemCatalogPresenter, 
        ItemSpawnerPresenter itemSpawnerPresenter,
        ItemsPresenter itemsPresenter,
        ScorePresenter scorePresenter)
    {
        this.globalStateMachineControl = globalStateMachineControl;
        this.sceneRoot = sceneRoot;
        this.triggerZonesPresenter = triggerZonesPresenter;
        this.fakeItemMovePresenter = fakeItemMovePresenter;
        this.itemCatalogPresenter = itemCatalogPresenter;
        this.itemSpawnerPresenter = itemSpawnerPresenter;
        this.itemsPresenter = itemsPresenter;
        this.scorePresenter = scorePresenter;
    }

    public void EnterState()
    {
        triggerZonesPresenter.OnFailGame += ChangeStateToPause;

        itemCatalogPresenter.OnSelectCurrentItem_Value += fakeItemMovePresenter.SetData;
        itemCatalogPresenter.OnSelectCurrentItem_Value += itemSpawnerPresenter.SetData;

        fakeItemMovePresenter.OnEndMove_Position += itemSpawnerPresenter.Spawn;
        fakeItemMovePresenter.OnSpawnNewItem += SelectSecondItem;

        itemsPresenter.OnAddNewItem += itemSpawnerPresenter.Spawn;
        itemsPresenter.OnAddScore += scorePresenter.AddScore;
        itemSpawnerPresenter.OnItemSpawned += itemsPresenter.AddItem;

        scorePresenter.ClearScore();
        itemCatalogPresenter.SelectSecondItemData();
        fakeItemMovePresenter.ActivateSmooth();

        sceneRoot.OpenGamePanels();
    }

    public void ExitState()
    {
        triggerZonesPresenter.OnFailGame -= ChangeStateToPause;

        itemCatalogPresenter.OnSelectCurrentItem_Value -= fakeItemMovePresenter.SetData;
        itemCatalogPresenter.OnSelectCurrentItem_Value -= itemSpawnerPresenter.SetData;

        fakeItemMovePresenter.OnEndMove_Position -= itemSpawnerPresenter.Spawn;
        fakeItemMovePresenter.OnSpawnNewItem -= SelectSecondItem;

        itemsPresenter.OnAddNewItem -= itemSpawnerPresenter.Spawn;
        itemsPresenter.OnAddScore -= scorePresenter.AddScore;
        itemSpawnerPresenter.OnItemSpawned -= itemsPresenter.AddItem;


        fakeItemMovePresenter.DeactivateSmooth();

        sceneRoot.CloseGamePanels();
    }

    private void ChangeStateToPause()
    {
        globalStateMachineControl.SetState(globalStateMachineControl.GetState<PauseState>());
    }

    private void SelectSecondItem()
    {
        Debug.Log("CALL");

        Coroutines.Start(SelectSecondItem_Coroutine());
    }

    private IEnumerator SelectSecondItem_Coroutine()
    {
        fakeItemMovePresenter.Deactivate();

        yield return new WaitForSeconds(0.4f);

        itemCatalogPresenter.SelectSecondItemData();
        fakeItemMovePresenter.ActivateSmooth();

        Debug.Log("ACTIVATE_SPAWN");
    }
}
