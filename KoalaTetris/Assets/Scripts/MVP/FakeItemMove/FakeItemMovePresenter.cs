using System;
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
        itemMoveView.OnActivatedItem_Action += itemMoveModel.Activate;
        itemMoveView.OnDeactivatedItem_Action += itemMoveModel.Deactivate;

        itemMoveView.OnPointerDown += itemMoveModel.StartMove;
        itemMoveView.OnPointerUp += itemMoveModel.EndMove;
        itemMoveView.OnPointerMove += itemMoveModel.Move;

        itemMoveModel.OnMove += itemMoveView.Move;
        itemMoveModel.OnTeleport += itemMoveView.Teleport;

        itemMoveModel.OnStartActivateSmooth += itemMoveView.ActivateSmooth;
        itemMoveModel.OnStartDeactivateSmooth += itemMoveView.DeactivateSmooth;
        itemMoveModel.OnStartActivate += itemMoveView.Activate;
        itemMoveModel.OnStartDeactivate += itemMoveView.Deactivate;
        itemMoveModel.OnSetData += itemMoveView.SetData;
        itemMoveModel.OnChangeScaleFactor += itemMoveView.SetScaleFactor;
    }

    private void DeactivateEvents()
    {
        itemMoveView.OnPointerDown -= itemMoveModel.StartMove;
        itemMoveView.OnPointerUp -= itemMoveModel.EndMove;
        itemMoveView.OnPointerMove -= itemMoveModel.Move;

        itemMoveModel.OnMove -= itemMoveView.Move;
        itemMoveModel.OnTeleport -= itemMoveView.Teleport;

        itemMoveModel.OnStartActivateSmooth -= itemMoveView.ActivateSmooth;
        itemMoveModel.OnStartDeactivateSmooth -= itemMoveView.DeactivateSmooth;
        itemMoveModel.OnStartDeactivate -= itemMoveView.Deactivate;
        itemMoveModel.OnSetData -= itemMoveView.SetData;
        itemMoveModel.OnChangeScaleFactor -= itemMoveView.SetScaleFactor;
    }

    #region Input

    public event Action OnStartMove
    {
        add { itemMoveModel.OnStartMove += value; }
        remove { itemMoveModel.OnStartMove -= value; }
    }

    public event Action OnEndMove
    {
        add { itemMoveModel.OnEndMove += value; }
        remove { itemMoveModel.OnEndMove -= value; }
    }

    public event Action OnSpawnNewItem
    {
        add { itemMoveModel.OnSpawn += value; }
        remove { itemMoveModel.OnSpawn -= value; }
    }

    public event Action<Vector3> OnEndMove_Position
    {
        add { itemMoveModel.OnEndMove_Position += value; }
        remove { itemMoveModel.OnEndMove_Position -= value; }
    }

    public void ActivateSmooth()
    {
        itemMoveModel.StartActivateSmooth();
    }

    public void DeactivateSmooth()
    {
        itemMoveModel.StartDeactivateSmooth();
    }

    public void Activate()
    {
        itemMoveModel.StartActivate();
    }

    public void Deactivate()
    {
        itemMoveModel.StartDeactivate();
    }

    public void SetData(ItemData itemData)
    {
        itemMoveModel.SetData(itemData);
    }

    public void SetScaleFactor(float scaleFactor)
    {
        itemMoveModel.SetScaleFactor(scaleFactor);
    }

    #endregion
}
