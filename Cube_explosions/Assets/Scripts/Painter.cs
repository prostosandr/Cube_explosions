using UnityEngine;

public class Painter : MonoBehaviour
{
    public void ChangeColor(Cube cube)
    {
        cube.Renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}