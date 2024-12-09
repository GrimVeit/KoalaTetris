using System;

public class TriggerZonesPresenter
{
    private TriggerZonesModel model;
    private TriggerZonesView view;

    public TriggerZonesPresenter(TriggerZonesModel model, TriggerZonesView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnFailGame += model.FailGame;
    }

    private void DeactivateEvents()
    {
        view.OnFailGame -= model.FailGame;
    }

    #region Input

    public event Action OnFailGame
    {
        add { model.OnFailGame += value; }
        remove { model.OnFailGame -= value; }
    }

    #endregion
}
