using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public event Action<List<Rigidbody>, Vector3, Quaternion> Exploded;

    private void OnEnable()
    {
        _cube.Spawned += Spawn;
    }

    private void OnDisable()
    {
        _cube.Spawned -= Spawn;
    }

    private void Spawn(GameObject gameObjectCube, float chanceTreshold)
    {
        System.Random random = new System.Random();

        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        int divisor = 2;
        int minCubesNumber = 2;
        int maxCubesNumber = 7;
        int minChance = 0;
        int maxChance = 101;

        _cube = gameObjectCube.GetComponent<Cube>();

        if (random.Next(minChance, maxChance) <= chanceTreshold)
        {
            int cubesNumber = random.Next(minCubesNumber, maxCubesNumber);

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject newCube = Instantiate(gameObjectCube);
                newCube.transform.localScale /= divisor;
                newCube.GetComponent<Cube>().DecreaseChance();
                newCube.GetComponent<Cube>().Spawned += Spawn;

                explodableObjects.Add(newCube.GetComponent<Rigidbody>());
            }
        }

        gameObjectCube.GetComponent<Cube>().Spawned -= Spawn;

        Exploded?.Invoke(explodableObjects, gameObjectCube.transform.position, gameObjectCube.transform.rotation);
    }
}