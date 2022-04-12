using UnityEngine;
using UnityEngine.Events;

public class MouseButtonClicker : MonoBehaviour
{
    public event UnityAction CursorPressed;
    public event UnityAction CursorReleased;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            CursorPressed?.Invoke();

        if (Input.GetMouseButtonUp(0))
            CursorReleased?.Invoke();
    }
}