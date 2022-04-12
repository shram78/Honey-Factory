using UnityEngine;

[RequireComponent(typeof(MouseButtonClicker))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _canMoveLayer;
    [SerializeField] private float _speed;

    private MouseButtonClicker _inputMouseComand;

    private void OnEnable()
    {
        _inputMouseComand = GetComponent<MouseButtonClicker>();

        _inputMouseComand.CursorPressed += Move;
    }

    private void OnDisable()
    {
        _inputMouseComand.CursorPressed -= Move;
    }

    private void Move()
    {
        Vector3 direction = GetPoint() - transform.position;

        direction.y = 0f;

        Rotate(direction);

        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;
    }

    private Vector3 GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, 100, _canMoveLayer))
            return raycastHit.point;

        return transform.position;
    }
}
