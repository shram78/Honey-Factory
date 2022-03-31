using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceHoneyBrick : MonoBehaviour
{
    [SerializeField] private bool _isInfinite;

    private HoneyBrick _brick;

    public bool IsAvailible { get; private set; }

    public event UnityAction<PlaceHoneyBrick> PlaceFree;
    public event UnityAction PlaceTaken;

    private void Start()
    {
        IsAvailible = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent(out HoneyBrick brick) && _brick == brick)
    //    {
    //        PlaceTaken?.Invoke();
    //    }
    //}

    public void Reserve(HoneyBrick honeyBrick)
    {
        IsAvailible = _isInfinite;
        _brick = honeyBrick;
        //_brick.GetComponent<Collectable>().Taken += Free;
    }

    //public void Free()
    //{
    //    IsAvailible = true;
    //    PlaceFree?.Invoke(this);
       // _brick.GetComponent<Collectable>().Taken -= Free;
   // }
}
