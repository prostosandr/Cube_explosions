using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceTreshold;

    public event Action<GameObject> MouseClick;

    public float ChanceTreshold => _chanceTreshold;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void OnMouseUpAsButton()
    {
        MouseClick?.Invoke(gameObject);
        Destroy(gameObject);
    }

    public void DecreaseChance()
    {
        int divisor = 2;

        _chanceTreshold /= divisor;
    }
}