using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private HoneyBrickContainer _honeyBrickContainer;
    [SerializeField] private Transform _spawnPoints; // one point
    [SerializeField] private HoneyBrick _honeyBrickTemplate;
    [SerializeField] private GameObject _hiveCover;

    public void InstantiateHoneyBrick()
    {
        OpenHiveCover();
        Debug.Log("Спаунер получил сообщение");

        HoneyBrickPlace brickPlace = _honeyBrickContainer.Places.FirstOrDefault(place => place.IsAvailible);
        if (brickPlace != default)
        {
            var brick = Instantiate(_honeyBrickTemplate, _spawnPoints.position, _honeyBrickTemplate.transform.rotation);
            brick.GetComponent<HoneyBrickMovable>().InitFlyRoute(brickPlace.transform.position, brickPlace.transform.rotation);

            brickPlace.Reserve(brick);

            _honeyBrickContainer.AddBrick();
        }
    }

    public void OpenHiveCover()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_hiveCover.transform.DOMoveX(0.6f, 0.2f)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(-0.1f, 0.1f)).SetRelative();
        sequence.Append(_hiveCover.transform.DOMoveX(0.1f, 0.1f)).SetRelative();

        sequence.Append(_hiveCover.transform.DOMoveX(0.1f, 0.1f).SetRelative().SetDelay(0.7f));
        sequence.Append(_hiveCover.transform.DOMoveX(-0.7f, 0.2f).SetRelative());
    }
}