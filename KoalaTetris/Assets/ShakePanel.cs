using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePanel : MonoBehaviour
{
    [SerializeField] private float shakeStrength = 0.5f;
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private int shakeVibrato = 10;
    [SerializeField] private float shakeRandomness = 90f;

    public void Initialize()
    {
        transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, false, true, ShakeRandomnessMode.Harmonic)
            .SetLoops(-1, LoopType.Restart);
    }

    public void Dispose()
    {

    }
}
