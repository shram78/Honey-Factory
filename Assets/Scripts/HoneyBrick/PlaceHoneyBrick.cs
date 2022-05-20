using UnityEngine;
using UnityEngine.Events;

public class PlaceHoneyBrick : MonoBehaviour
{
    private HoneyBrick _honeyBrick;

    public bool IsAvailible { get; private set; }

    private void Start()
    {
        IsAvailible = true;
    }

    public void Reserve(HoneyBrick honeyBrick)
    {
        IsAvailible = false;
        _honeyBrick = honeyBrick;
        _honeyBrick.GetComponent<CollectableHoneyBrick>().Taken += Free;
    }

    public void Free() 
    {
        IsAvailible = true;
       _honeyBrick.GetComponent<CollectableHoneyBrick>().Taken -= Free;
    }
}
