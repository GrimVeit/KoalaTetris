using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectModel
{
    public event Action OnActivateEffect;
    
    public Dictionary<string, ParticleEffect> particleEffects = new Dictionary<string, ParticleEffect>();
    public Dictionary<string, ParticleSpawnEffect> particleSpawnEffects = new Dictionary<string, ParticleSpawnEffect>();

    public void Initialize(ParticleEffect[] effects, ParticleSpawnEffect[] spawnEffects)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            particleEffects.Add(effects[i].ID, effects[i]);
            effects[i].Initialize();
        }

        for (int i = 0; i < spawnEffects.Length; i++)
        {
            particleSpawnEffects.Add(spawnEffects[i].ID, spawnEffects[i]);
            spawnEffects[i].Initialize();
        }
    }

    public void Dispose()
    {
        foreach (var item in particleEffects.Values)
        {
            item.Dispose();
        }

        foreach (var item in particleSpawnEffects.Values)
        {
            item.Dispose();
        }
    }

    public void Play(string ID)
    {
        if (particleEffects.ContainsKey(ID))
        {
            OnActivateEffect?.Invoke();
            particleEffects[ID].Play();
            return;
        }

        Debug.Log("Ёффект с идентификатором " + ID + "не был найден");
    }

    public void Play(string ID, Vector3 vector)
    {
        if (particleSpawnEffects.ContainsKey(ID))
        {
            OnActivateEffect?.Invoke();
            particleSpawnEffects[ID].Play(vector);
            return;
        }

        Debug.Log("Ёффект с идентификатором " + ID + "не был найден");
    }

    public IParticleEffect GetParticleEffect(string id)
    {
        if (particleEffects.ContainsKey(id))
        {
            return particleEffects[id];
        }

        Debug.Log("Ёффект с идентификатором " + id + "не был найден");
        return null;
    }
}
