using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int chanceTreshold;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(_effect, transform.position, transform.rotation);
        SpawnCubes();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }

    private void SpawnCubes()
    {
        System.Random randomNumber = new System.Random();

        int divisor = 2;
        int minCubesNumber = 2;
        int maxCubesNumber = 6;
        int minChance = 0;
        int maxChance = 100;

        if (randomNumber.Next(minChance, maxChance++) <= chanceTreshold)
        {
            int cubesNumber = randomNumber.Next(minCubesNumber, maxCubesNumber++);

            chanceTreshold /= divisor;

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject newCube = Instantiate(gameObject);
                newCube.transform.localScale /= divisor;

                newCube.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            }
        }
    }
}
