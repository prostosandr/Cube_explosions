using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.Spawned += Spawn;
    }

    private void OnDisable()
    {
        _cube.Spawned -= Spawn;
    }

    private void Spawn(GameObject gameObjectCube, float chanceTreshold, List<Rigidbody> _explodableObjects)
    {
        System.Random random = new System.Random();

        int divisor = 2;
        int minCubesNumber = 2;
        int maxCubesNumber = 6;
        int minChance = 0;
        int maxChance = 100;

        _cube = gameObjectCube.GetComponent<Cube>();

        if (random.Next(minChance, maxChance++) <= chanceTreshold)
        {
            int cubesNumber = random.Next(minCubesNumber, maxCubesNumber++);

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject newCube = Instantiate(gameObjectCube);
                newCube.transform.localScale /= divisor;
                newCube.GetComponent<Cube>().DecreaseChance();
                newCube.GetComponent<Cube>().Spawned += Spawn;

                _explodableObjects.Add(newCube.GetComponent<Rigidbody>());
            }
        }
    }
}