using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.Exploded += Explode;
    }

    private void OnDisable()
    {
        _cube.Exploded -= Explode;
    }

    private void Explode(List<Rigidbody> explodableObjects)
    {
        Instantiate(_effect, transform.position, transform.rotation);

        foreach (Rigidbody explodableObject in explodableObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}