using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SpawnInterractiveObjectPlace : MonoBehaviour
{
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

            GameObject gameObject = Instantiate(_prefabTemplate, _spawnPoint.transform.position, _spawnPoint.transform.rotation);

            CreateSpawnEffect(gameObject);
        }
    }

    protected virtual void CreateSpawnEffect(GameObject gameObject)
    {
        Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);
        float TimeEffect = 0.5f;

        gameObject.transform.DOPunchScale(targetScale, TimeEffect, 1, 1);
    }
}
