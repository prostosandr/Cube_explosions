using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Detonator _detonator;

    private void OnEnable()
    {
        _cube.MouseClick += Spawn;
    }

    private void OnDisable()
    {
        _cube.MouseClick -= Spawn;
    }

    private void Spawn(GameObject gameObjectCube)
    {
        System.Random random = new System.Random();

        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        int divisor = 2;
        int minCubesNumber = 2;
        int maxCubesNumber = 7;
        int minChance = 0;
        int maxChance = 101;

        _cube = gameObjectCube.GetComponent<Cube>();

        if (random.Next(minChance, maxChance) <= gameObjectCube.GetComponent<Cube>().ChanceTreshold)
        {
            int cubesNumber = random.Next(minCubesNumber, maxCubesNumber);

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject newCube = Instantiate(gameObjectCube);
                newCube.transform.localScale /= divisor;
                newCube.GetComponent<Cube>().DecreaseChance();
                newCube.GetComponent<Cube>().MouseClick += Spawn;

                explodableObjects.Add(newCube.GetComponent<Rigidbody>());
            }
        }

        _detonator.Explode(explodableObjects, gameObjectCube.transform.position, gameObjectCube.transform.rotation);

        gameObjectCube.GetComponent<Cube>().MouseClick -= Spawn;
    }
}