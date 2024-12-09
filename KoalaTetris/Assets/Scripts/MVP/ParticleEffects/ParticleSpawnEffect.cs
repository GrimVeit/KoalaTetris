using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ParticleSpawnEffect
{
    public string ID;

    public ParticleSpawn particle;

    private IEnumerator coroutineParticles;

    public void Initialize()
    {
        particle.Initialize();
    }

    public void Dispose()
    {
        particle.Dispose();
    }

    public void Play(Vector3 vector)
    {
        particle.Play(vector);
    }
}

[Serializable]
public class ParticleSpawn
{
    [SerializeField] private ParticleSystem particleSystemPrefab;
    [SerializeField] private Transform particleTransform;

    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void Play(Vector3 vector)
    {
        var particle = UnityEngine.Object.Instantiate(particleSystemPrefab);
        particle.transform.SetLocalPositionAndRotation(new Vector3(vector.x, vector.y, -100), particleSystemPrefab.transform.rotation);

        float randomSize = UnityEngine.Random.Range(minSize, maxSize);

        particle.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        particle.Play();
    }
}
