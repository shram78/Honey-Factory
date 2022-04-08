using UnityEngine;

public class ShowWIdgetAfterSpawn : MonoBehaviour
{
    [SerializeField] protected GameObject _panel;

    private float elapsedTime = 0;
    private float _currentSpawnDelay = 6f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= _currentSpawnDelay)
            Show();
    }

    private void Show()
    {
        _panel.gameObject.SetActive(true);
    }
}
