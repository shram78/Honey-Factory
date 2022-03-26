using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private HoneyBrickContainer _honeyBrickContainer;
    [SerializeField] private Transform _spawnPoints; // one point
    [SerializeField] private HoneyBrick _honeyBrickTemplate;

    private float elapsedTime = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _spawnDelay)
        {
           // for (int i = 0; i < _spawnPoints.Length; i++)
            {
                HoneyBrickPlace brickPlace = _honeyBrickContainer.Places.FirstOrDefault(place => place.IsAvailible);

                if (brickPlace != default)
                {
                    var brick = Instantiate(_honeyBrickTemplate, _spawnPoints.position, _honeyBrickTemplate.transform.rotation);
                    brick.GetComponent<Flyable>().InitFlyRoute(brickPlace.transform.position, brickPlace.transform.rotation);

                    brickPlace.Reserve(brick);

                    _honeyBrickContainer.AddBrick();
                }
            }

            elapsedTime = 0;
        }
    }

}
