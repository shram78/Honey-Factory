using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _honeyBrickContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private HoneyBrick _honeyBrickTemplate;
    [SerializeField] private GameObject _hiveCover;

    private float elapsedTime = 0;
    private float _currentSpawnDelay = 2f;


    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _currentSpawnDelay)
        {
            InstantiateHoneyBrick();

            elapsedTime = 0;
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
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_hiveCover.transform.DOMoveX(0.6f, 0.2f)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(-0.1f, 0.1f)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(0.1f, 0.1f)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(0.1f, 0.1f).SetRelative().SetDelay(0.7f));
        sequence.Append(_hiveCover.transform.DOMoveX(-0.7f, 0.2f).SetRelative());
    }
}