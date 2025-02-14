using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private const int Divisor = 2;

    [SerializeField] private float _chanceTreshold;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;
    [SerializeField] private Painter _painter;

    public Rigidbody Rigidbody => GetComponent<Rigidbody>();
    public Renderer Renderer => GetComponent<Renderer>();
    public float ChanceTreshold => _chanceTreshold;
    public Vector3 CurrentScale => transform.localScale;

    private void Awake()
    {
        _painter.ChangeColor(this);
    }

    public void GoLifeCycle()
    {
        if (GetSpawnChance())
        {
            _spawner.Spawn(this, GetNumberOfCubesSpawn());
        }

        _detonator.Explode(_spawner.SpawnList, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    public void DecreaseParametrs()
    {
        _chanceTreshold /= Divisor;
        transform.localScale /= Divisor;
    }

    public void SetChanceTreshold(float newChance)
    {
        _chanceTreshold = newChance;
    }

    private bool GetSpawnChance()
    {
        System.Random random = new System.Random();

        int minChance = 0;
        int maxChance = 101;


        bool canSpawn = false;

        if (random.Next(minChance, maxChance) <= _chanceTreshold)
            canSpawn = true;

        return canSpawn;
    }

    private int GetNumberOfCubesSpawn()
    {
        System.Random random = new System.Random();

        int minNumberOfCubes = 2;
        int maxNumberOfCubes = 7;

        return random.Next(minNumberOfCubes, maxNumberOfCubes);
    }
}
