using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.Exploded += Explode;
    }

    private void OnDisable()
    {
        _spawner.Exploded -= Explode;
    }

    private void Explode(List<Rigidbody> explodableObjects, Vector3 particlePosition, Quaternion particleRotation)
    {
        Instantiate(_effect, particlePosition, particleRotation);

        foreach (Rigidbody explodableObject in explodableObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}