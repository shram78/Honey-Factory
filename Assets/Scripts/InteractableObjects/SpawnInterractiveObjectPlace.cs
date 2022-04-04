using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SpawnInterractiveObjectPlace : MonoBehaviour
{
    //[SerializeField] private Flowerbed _flowerbedTemplate;
    [SerializeField] private GameObject _prefabTemplate;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private DeliveryHoneyBrick _deliveryHoney;

    public event UnityAction SpawnComplete;

    private void OnCollisionStay(Collision collision)
    {
        if (_deliveryHoney.CollectedAll() && collision.gameObject.TryGetComponent(out Player player))
        {
            base.gameObject.SetActive(false);

            SpawnComplete?.Invoke();

            // Flowerbed flowerbed = Instantiate(_prefabTemplate, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
            GameObject gameObject = Instantiate(_prefabTemplate, _spawnPoint.transform.position, _spawnPoint.transform.rotation);

            CreateSpawnEffect(gameObject);
        }
    }

    private void CreateSpawnEffect(GameObject flowerbed)
    {
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);

        flowerbed.transform.DOPunchScale(targetScale, 0.5f, 1, 0.9f);
    }
}
