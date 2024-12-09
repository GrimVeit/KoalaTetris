using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    [SerializeField] private Vector3 scaleMax;
    [SerializeField] private Vector3 scaleMin;
    [SerializeField] private float duration;
    [SerializeField] private bool isAwake;
    [SerializeField] private Transform scaleElement;

    public void Initialize()
    {
        scaleElement.localScale = scaleMin;

        if (isAwake)
            ActivateEffect();
    }

    public void Dispose()
    {

    }

    public void ActivateEffect()
    {
        scaleElement.DOScale(scaleMax, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
