using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceHoneyBrick : MonoBehaviour
{
    [SerializeField] private bool _isInfinite;//

    private HoneyBrick _honeyBrick;

    public bool IsAvailible { get; private set; }

    public event UnityAction<PlaceHoneyBrick> PlaceFree;

    private void Start()
    {
        IsAvailible = true;
    }

    public void Reserve(HoneyBrick honeyBrick)
    {
        IsAvailible = _isInfinite;
        _honeyBrick = honeyBrick;
        _honeyBrick.GetComponent<CollectableHoneyBrick>().Taken += Free;
    }

    public void Free() // очищает в спаунере свободные слоты
    {
        IsAvailible = true;
        PlaceFree?.Invoke(this);
       _honeyBrick.GetComponent<CollectableHoneyBrick>().Taken -= Free;
    }
}
