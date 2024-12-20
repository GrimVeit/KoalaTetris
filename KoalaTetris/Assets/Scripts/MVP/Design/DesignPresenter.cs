using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignPresenter
{
    private DesignModel model;
    private DesignView view;

    public DesignPresenter(DesignModel model, DesignView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        model.OnSetDesign += view.SetDesign;
    }

    private void DeactivateEvents()
    {
        model.OnSetDesign -= view.SetDesign;
    }

    #region Input

    public void SetDesign(GameType gameType)
    {
        model.SetDesign(gameType.Design);
    }

    #endregion
}
