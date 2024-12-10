using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParticleSystem : MaskableGraphic
{
    [SerializeField] private ParticleSystemRenderer systemRenderer;
    [SerializeField] private Camera _bakeCamera;

    private void Update()
    {
        SetVerticesDirty();
    }

    [System.Obsolete]
    protected override void OnPopulateMesh(Mesh m)
    {
        m.Clear();

        if(systemRenderer != null && _bakeCamera != null)
        {
            //systemRenderer.BakeMesh(m, _bakeCamera);

            systemRenderer.BakeMesh(m, _bakeCamera);
        }
    }
}
