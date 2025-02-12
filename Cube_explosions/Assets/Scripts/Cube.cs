using System;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<List<Rigidbody>> Spawned;
    public event Action<List<Rigidbody>> Exploded;

    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void OnMouseUpAsButton()
    {
        List<Rigidbody> _objects = new List<Rigidbody>();

        Spawned?.Invoke(_objects);
        Exploded?.Invoke(_objects);
        Destroy(gameObject);
    }
}