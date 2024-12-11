using System;
using UnityEngine;

public class AdaptiveScreenModel
{
    public event Action<float> OnChangeScreenFactor;

    public void Initialize()
    {
        float currentWidth = Screen.width;
        float currentHeight = Screen.height;

        float widthRatio = currentWidth / 1080f;
        float heigthRatio = currentHeight / 1920f;

        float scaleFactor = Mathf.Min(widthRatio, heigthRatio);

        Debug.Log(scaleFactor);

        OnChangeScreenFactor?.Invoke(scaleFactor);
    }

    public void Dispose()
    {

    }
}
