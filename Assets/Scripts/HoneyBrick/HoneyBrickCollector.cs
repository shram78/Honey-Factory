using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoneyBrickCollector : MonoBehaviour
{
    [SerializeField] private HoneyBrickContainer _brickContainer;
    [SerializeField] private int _brickCount = 0;
    [SerializeField] private BoxCollider _brickCollector;

    public int BrickCount => _brickCount;
    public HoneyBrickContainer BrickContainer => _brickContainer;
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

            Debug.Log("IM full!!!");

        }
    }

}
