using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
