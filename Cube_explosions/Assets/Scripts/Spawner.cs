using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float chanceTreshold;

    private void OnEnable()
    {
        _cube.Spawned += Spawn; 
    }

    private void OnDisable()
    {
        _cube.Spawned -= Spawn;
    }

    private void Spawn(List<Rigidbody> explodableObjects)
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

                explodableObjects.Add(newCube.GetComponent<Rigidbody>());
            }
        }
    }
}