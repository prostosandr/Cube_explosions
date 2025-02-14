using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    private List<Rigidbody> _spawnList = new List<Rigidbody>();

    public List<Rigidbody> SpawnList => _spawnList;

    public void Spawn(Cube oldCube, int numberOfCubes)
    {
        _spawnList.Clear();

        for (int i = 0; i < numberOfCubes; i++)
        {
            GameObject newGameObjectCube = Instantiate(_prefabCube, oldCube.transform.position, oldCube.transform.rotation);

            if(newGameObjectCube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                _spawnList.Add(rigidbody);
            }

            if(newGameObjectCube.TryGetComponent<Cube>(out Cube cube))
            {
                cube.transform.localScale = oldCube.CurrentScale;
                cube.SetChanceTreshold(oldCube.ChanceTreshold);
                
                cube.DecreaseParametrs();
            }
        }
    }
}