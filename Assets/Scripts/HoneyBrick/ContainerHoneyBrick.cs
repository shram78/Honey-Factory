using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerHoneyBrick : MonoBehaviour
{
    [SerializeField] private List<PlaceHoneyBrick> _honeyBrickPlaces;

    private int _currentHoneyBricksCollected;

    public IReadOnlyList<PlaceHoneyBrick> Places => _honeyBrickPlaces;

    private int _needHoneyBricksToBuy => _honeyBrickPlaces.Count;

    public event UnityAction<int, int> BrickAmountChanged;
    public event UnityAction BrickPlaced;
   // public event UnityAction BuildingComplete; // rename

    private void Start()
    {
        BrickAmountChanged?.Invoke(_needHoneyBricksToBuy, _currentHoneyBricksCollected);
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _honeyBrickPlaces.Add(transform.GetChild(i).GetComponent<PlaceHoneyBrick>());

             _honeyBrickPlaces[i].PlaceFree += OnBrickTaken;
        }

          // _honeyBrickPlaces[transform.childCount - 1].PlaceTaken += OnLastPlaceTaken;
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _honeyBrickPlaces[i].PlaceFree -= OnBrickTaken;
        }

        // _honeyBrickPlaces[transform.childCount - 1].PlaceTaken -= OnLastPlaceTaken;
    }

    public void AddBrick()
    {
        _currentHoneyBricksCollected++;
        BrickPlaced?.Invoke();

        BrickAmountChanged?.Invoke(_needHoneyBricksToBuy, _currentHoneyBricksCollected);
    }

    private void OnBrickTaken(PlaceHoneyBrick position)
    {
        _currentHoneyBricksCollected--;
        BrickAmountChanged?.Invoke(_currentHoneyBricksCollected, _needHoneyBricksToBuy);
    }

    public void CanIBuild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _honeyBrickPlaces.Add(transform.GetChild(i).GetComponent<PlaceHoneyBrick>());

            _honeyBrickPlaces[i].PlaceFree += OnBrickTaken;
        }


        Debug.Log("ְֽ׳ְָֽÞ סענמטעü");
    }

    //private void OnLastPlaceTaken()
    //{
    //    BuildingComplete?.Invoke();
    //    Debug.Log("Complete!!!!!");
    //}
}
