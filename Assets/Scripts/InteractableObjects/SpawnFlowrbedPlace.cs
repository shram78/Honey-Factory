using UnityEngine;
using DG.Tweening;

public class SpawnFlowrbedPlace : MonoBehaviour
{
    [SerializeField] private Flowerbed _flowerbedTemplate;
    [SerializeField] private Transform _spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
       // Flowerbed flowerbed = Instantiate(_flowerbedTemplate, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
;
      //  ChangeScaleBeforeSpawn(flowerbed);
    }

    private void ChangeScaleBeforeSpawn(Flowerbed flowerbed)
    {
        Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);

        flowerbed.transform.DOPunchScale(targetScale, 0.3f, 1, 0.9f);
    }
}
