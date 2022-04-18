using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _honeyBrickContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private HoneyBrick _honeyBrickTemplate;
    [SerializeField] private GameObject _hiveCover;

    private float _elapsedTime = 0;
    private float _currentSpawnDelay = 2f;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _currentSpawnDelay)
        {
            InstantiateHoneyBrick();

            _elapsedTime = 0;
        }
    }

    private void InstantiateHoneyBrick()
    {
        PlaceHoneyBrick brickPlace = _honeyBrickContainer.Places.FirstOrDefault(place => place.IsAvailible);
        if (brickPlace != null)
        {
            OpenHiveCover(); 

            HoneyBrick brick = Instantiate(_honeyBrickTemplate, _spawnPoint.position, _honeyBrickTemplate.transform.rotation);

            brick.GetComponent<MovableHoneyBrick>().MoveFromHive(brickPlace.transform.position);

            brickPlace.Reserve(brick);

            _honeyBrickContainer.AddBrick();
        }
    }

    private void OpenHiveCover()
    {
        float FirstOpenValue = 0.3f;
        float SecondOpenValue = -0.05f;
        float ThirdOpenValue = 0.05f;
        float FourthOpenValue = 0.1f;
        float FifthOpenValue = -0.4f;
        float TimeToMoveFirstValue = 0.2f;
        float TimeToMoveSecondValue = 0.1f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_hiveCover.transform.DOMoveX(FirstOpenValue, TimeToMoveFirstValue)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(SecondOpenValue, TimeToMoveSecondValue)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(ThirdOpenValue, TimeToMoveSecondValue)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(FourthOpenValue, TimeToMoveSecondValue).SetRelative().SetDelay(0.7f));
        sequence.Append(_hiveCover.transform.DOMoveX(FifthOpenValue, TimeToMoveFirstValue).SetRelative());
    }
}