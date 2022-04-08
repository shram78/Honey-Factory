using UnityEngine;

public class OrientationOnScreenWidget : MonoBehaviour
{
    private Canvas _canvas;
    private Quaternion _rotateToCamera;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _rotateToCamera = Camera.main.transform.rotation;
    }

    private void LateUpdate()
    {
        if (_canvas.transform.rotation != _rotateToCamera)
            _canvas.transform.rotation = _rotateToCamera;
    }
}
