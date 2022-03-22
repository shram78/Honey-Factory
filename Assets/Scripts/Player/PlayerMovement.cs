using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputMouseComand))]
[RequireComponent(typeof(Player))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private InputMouseComand _inputMouseComand;
    private MouseClickChecker _mouseClickChecker;

    public event UnityAction Walking;

    private void Start()
    {
        _mouseClickChecker = GetComponent<MouseClickChecker>();
    }

    private void OnEnable()
    {
        _inputMouseComand = GetComponent<InputMouseComand>();


        _inputMouseComand.OnCursorPressed += Move;
    }

    private void OnDisable()
    {
        _inputMouseComand.OnCursorPressed -= Move;
    }

    private void Move()
    {
        Vector3 direction = _mouseClickChecker.GetPoint() - transform.position;
        direction.y = 0f;

        Rotate(direction);
      
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        Walking?.Invoke();
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;
    }
}
