using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectorHoneyBrick : MonoBehaviour
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
}
