using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceTreshold;

    public event Action<GameObject, float> Spawned;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void OnMouseUpAsButton()
    {
        Spawned?.Invoke(gameObject, _chanceTreshold);
        Destroy(gameObject);
    }

    public void DecreaseChance()
    {
        int divisor = 2;

        _chanceTreshold /= divisor;
    }
}