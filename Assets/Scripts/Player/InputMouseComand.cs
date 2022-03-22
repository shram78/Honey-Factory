using UnityEngine;
using UnityEngine.Events;

public class InputMouseComand : MonoBehaviour
{
    public event UnityAction OnCursorPressed;
    public event UnityAction OnCursorReleased;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            OnCursorPressed?.Invoke();

        if (Input.GetMouseButtonUp(0))
            OnCursorReleased?.Invoke();
    }
}