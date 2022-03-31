using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerHoneyBrick : MonoBehaviour
{
    [SerializeField] private List<PlaceHoneyBrick> _honeyBrickPlaces;

    private int _currentBricksAmount;

    public IReadOnlyList<PlaceHoneyBrick> Places => _honeyBrickPlaces;

    private int _maxBricksAmount => _honeyBrickPlaces.Count;

    public event UnityAction<int, int> BrickAmountChanged;
    public event UnityAction BrickPlaced;
    public event UnityAction BuildingComplete;

    private void Start()
    {
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _honeyBrickPlaces.Add(transform.GetChild(i).GetComponent<PlaceHoneyBrick>());

            _honeyBrickPlaces[i].PlaceFree += OnBrickTaken;
        }

        _honeyBrickPlaces[transform.childCount - 1].PlaceTaken += OnLastPlaceTaken;
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _honeyBrickPlaces[i].PlaceFree -= OnBrickTaken;
        }

        _honeyBrickPlaces[transform.childCount - 1].PlaceTaken -= OnLastPlaceTaken;
    }

    public void AddBrick()
    {
        _currentBricksAmount++;
        BrickPlaced?.Invoke();

        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnBrickTaken(PlaceHoneyBrick position)
    {
        _currentBricksAmount--;
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnLastPlaceTaken()
    {
        BuildingComplete?.Invoke();
    }
}
