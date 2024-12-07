using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeItemMovePresenter
{
    private FakeItemMoveModel itemMoveModel;
    private FakeItemMoveView itemMoveView;

    public FakeItemMovePresenter(FakeItemMoveModel itemMoveModel, FakeItemMoveView itemMoveView)
    {
        this.itemMoveModel = itemMoveModel;
        this.itemMoveView = itemMoveView;
    }

    public void Initialize()
    {
        ActivateEvents();

        itemMoveModel.Initialize();
        itemMoveView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        itemMoveModel.Dispose();
        itemMoveView.Dispose();
    }

    private void ActivateEvents()
    {
        itemMoveView.OnPointerDown += itemMoveModel.StartMove;
        itemMoveView.OnPointerUp += itemMoveModel.EndMove;
        itemMoveView.OnPointerMove += itemMoveModel.Move;

        itemMoveModel.OnMove += itemMoveView.Move;
        itemMoveModel.OnTeleport += itemMoveView.Teleport;

        itemMoveModel.OnActivate += itemMoveView.Activate;
        itemMoveModel.OnDeactivate += itemMoveView.Deactivate;
        itemMoveModel.OnSetData += itemMoveView.SetData;
    }

    private void DeactivateEvents()
    {
        itemMoveView.OnPointerDown -= itemMoveModel.StartMove;
        itemMoveView.OnPointerUp -= itemMoveModel.EndMove;
        itemMoveView.OnPointerMove -= itemMoveModel.Move;

        itemMoveModel.OnMove -= itemMoveView.Move;
        itemMoveModel.OnTeleport -= itemMoveView.Teleport;

        itemMoveModel.OnActivate -= itemMoveView.Activate;
        itemMoveModel.OnDeactivate -= itemMoveModel.Deactivate;
        itemMoveModel.OnSetData -= itemMoveView.SetData;
    }

    #region Input

    public void Activate()
    {
        itemMoveModel.Activate();
    }

    public void Deactivate()
    {
        itemMoveModel.Deactivate();
    }

    public void SetData(ItemData itemData)
    {
        itemMoveModel.SetData(itemData);
    }

    #endregion
}
