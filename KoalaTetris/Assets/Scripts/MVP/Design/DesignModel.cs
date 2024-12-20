using System;

public class DesignModel
{
    public event Action<Design> OnSetDesign;

    public void SetDesign(Design design)
    {
        OnSetDesign?.Invoke(design);
    }
}
