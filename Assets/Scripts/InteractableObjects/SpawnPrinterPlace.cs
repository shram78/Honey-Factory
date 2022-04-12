using UnityEngine;

public class SpawnPrinterPlace : MonoBehaviour
{
    [SerializeField] private SpawnScatePlace _spawnScatePlace;
    [SerializeField] private GameObject _hideObject;

    private void OnEnable()
    {
        _spawnScatePlace.SpawnComplete += OnShowPlace;
    }

    private void OnShowPlace()
    {
        _hideObject.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _spawnScatePlace.SpawnComplete -= OnShowPlace;
    }
}