using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Detonator _detonator;

    private void OnEnable()
    {
        _cube.MouseClicked += Spawn;
    }

    private void OnDisable()
    {
        _cube.MouseClicked -= Spawn;
    }

    private void Spawn(Cube cube)
    {
        System.Random random = new System.Random();

        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        int divisor = 2;
        int minCubesNumber = 2;
        int maxCubesNumber = 7;
        int minChance = 0;
        int maxChance = 101;

        _cube = cube;

        if (random.Next(minChance, maxChance) <= _cube.ChanceTreshold)
        {
            int cubesNumber = random.Next(minCubesNumber, maxCubesNumber);

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject newCube = Instantiate(_cube.gameObject);
                newCube.transform.localScale /= divisor;
                newCube.GetComponent<Cube>().DecreaseChance();
                newCube.GetComponent<Cube>().MouseClicked += Spawn;

                explodableObjects.Add(newCube.GetComponent<Cube>().Rigidbody);
            }
        }

        _detonator.Explode(explodableObjects, _cube.gameObject.transform.position, _cube.gameObject.transform.rotation);

        _cube.MouseClicked -= Spawn;
    }
}