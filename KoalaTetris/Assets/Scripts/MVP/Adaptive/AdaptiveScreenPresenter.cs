using System;

public class AdaptiveScreenPresenter
{
    private AdaptiveScreenModel adaptiveScreenModel;

    public AdaptiveScreenPresenter(AdaptiveScreenModel adaptiveScreenModel)
    {
        this.adaptiveScreenModel = adaptiveScreenModel;
    }

    public void Initialize()
    {
        adaptiveScreenModel.Initialize();
    }

    public void Dispose()
    {
        adaptiveScreenModel.Dispose();
    }

    #region Input

    public event Action<float> OnChangeScreenFactor
    {
        add { adaptiveScreenModel.OnChangeScreenFactor += value; }
        remove { adaptiveScreenModel.OnChangeScreenFactor -= value; }
    }

    #endregion
}
