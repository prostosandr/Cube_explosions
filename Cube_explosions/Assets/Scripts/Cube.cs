using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceTreshold;

    public event Action<Cube> MouseClicked;
    
    public float ChanceTreshold => _chanceTreshold;
    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    private void Awake()
    {
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void OnMouseUpAsButton()
    {
        MouseClicked?.Invoke(this);
        Destroy(gameObject);
    }

    public void DecreaseChance()
    {
        int divisor = 2;

        _chanceTreshold /= divisor;
    }
}