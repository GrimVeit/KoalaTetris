using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveBox : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransrom;

    [SerializeField] private List<RectTransform> others = new List<RectTransform>();

    private Vector2 defaultBoxSize = new Vector2(970, 1080);

    private void AdjustBoxSize()
    {
        float currentWidth = Screen.width;
        float currentHeight = Screen.height;

        float widthRatio = currentWidth / 1080f;
        float heigthRatio = currentHeight / 1920f;

        float scaleFactor = Mathf.Min(widthRatio, heigthRatio);

        //Debug.Log(scaleFactor);

        rectTransrom.localScale = new Vector2(scaleFactor, scaleFactor);

        for (int i = 0; i < others.Count; i++)
        {
            others[i].sizeDelta = others[i].sizeDelta * scaleFactor;
        }
    }

    private void Update()
    {
        AdjustBoxSize();
    }
}
