using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _brickContainer;
    [SerializeField] private BoxCollider _brickCollector;

    private int _brickCount = 0;

    public int BrickCount => _brickCount;

    public ContainerHoneyBrick BrickContainer => _brickContainer;

    private bool _isFull => _brickCount >= _brickContainer.Places.Count;

    public event UnityAction BrickCollected;
    public event UnityAction BrickGiven;

    public void Put()
    {
        BrickCollected?.Invoke();
        _brickCount++;

        if (_isFull)
        {
            _brickCollector.enabled = false;
        }
    }

    public HoneyBrick GiveBrick(Vector3 targetPosition, Quaternion targetRotation)
    {
        HoneyBrick honeyBrick = null;

        if (_brickCount > 0)
        {
            _brickCount--;

            honeyBrick = transform.GetChild(_brickCount).GetComponent<HoneyBrick>();

            BrickGiven?.Invoke();

            if (_brickCollector.enabled == false && _isFull == false)
                _brickCollector.enabled = true;
        }

        return honeyBrick;
    }
}
