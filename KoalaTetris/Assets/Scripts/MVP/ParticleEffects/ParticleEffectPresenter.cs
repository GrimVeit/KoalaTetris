using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectPresenter : IParticleEffectProvider
{
    private ParticleEffectModel effectModel;
    private ParticleEffectView effectView;

    public ParticleEffectPresenter(ParticleEffectModel effectModel, ParticleEffectView effectView)
    {
        this.effectModel = effectModel;
        this.effectView = effectView;
    }

    public void Initialize()
    {
        effectModel.Initialize(effectView.particleEffects.effects.ToArray(), effectView.particleEffects.spawnEffects.ToArray());
    }

    public void Dispose()
    {
        effectModel.Dispose();
    }

    public void Play(string ID)
    {
        effectModel.Play(ID);
    }

    public void Play(string ID, Vector3 vector)
    {
        effectModel.Play(ID, vector);
    }

    public IParticleEffect GetParticleEffect(string ID)
    {
        return effectModel.GetParticleEffect(ID);
    }
}

public interface IParticleEffectProvider
{
    void Play(string ID);
    void Play(string ID, Vector3 vector);
    IParticleEffect GetParticleEffect(string ID);
}
