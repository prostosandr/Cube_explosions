using UnityEngine;
using UnityEngine.Events;

public class MouseKeyReader : MonoBehaviour
{
    public UnityEvent OnMouseClick;

    private void OnMouseUpAsButton()
    {
        OnMouseClick?.Invoke();
    }
}