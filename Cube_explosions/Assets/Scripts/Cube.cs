using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float chanceTreshold;

    public event Action<GameObject, float, List<Rigidbody>> Spawned;
    public event Action<List<Rigidbody>> Exploded;

    public void DecreaseChance()
    {
        int divisor = 2;

        chanceTreshold /= divisor;
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void OnMouseUpAsButton()
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        Spawned?.Invoke(gameObject, chanceTreshold, explodableObjects);
        Exploded?.Invoke(explodableObjects);
        Destroy(gameObject);
    }
}