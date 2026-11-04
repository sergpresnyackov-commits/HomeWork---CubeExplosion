using UnityEngine;

public class DivideEffectSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _divideEffect;
    [SerializeField] private ParticleSystem _explosionEffect;

    public void SpawnDivideEffect(Vector3 position)
    {
        Instantiate(_divideEffect, position, Quaternion.identity);
    }

    public void SpawnExplosionEffect(Vector3 position)
    {
        Instantiate(_explosionEffect, position, Quaternion.identity);
    }
}