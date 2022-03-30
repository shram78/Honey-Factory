using UnityEngine;

public class SpawnFlowrbedPlace : MonoBehaviour
{
    [SerializeField] private Flowerbed _flowerbedTemplate;
    [SerializeField] private Transform _spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
         var flowerbed = Instantiate(_flowerbedTemplate, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
    }
}
