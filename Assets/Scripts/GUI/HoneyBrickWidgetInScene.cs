using UnityEngine;
using TMPro;

public class HoneyBrickWidgetInScene : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private TMP_Text _honeyBrickText;
    [SerializeField] private SpawnInterractiveObjectPlace _spawnFlowrbedPlace;

    private Canvas _canvas;
    private Quaternion _rotateToCamera;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _rotateToCamera = Camera.main.transform.rotation;
    }

    private void OnEnable()
    {
        _container.BrickAmountChanged += OnShowCount;
        _spawnFlowrbedPlace.SpawnComplete += OnHide;
    }

    private void OnDisable()
    {
        _container.BrickAmountChanged -= OnShowCount;
        _spawnFlowrbedPlace.SpawnComplete -= OnHide;
    }

    private void OnShowCount(int needHoneyBricksToBuy, int currentHoneyBricksCollected)
    {
        int honeyBrickToShow = needHoneyBricksToBuy - currentHoneyBricksCollected;
        _honeyBrickText.text = honeyBrickToShow.ToString();
    }

    private void OnHide()
    {
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (_canvas.transform.rotation != _rotateToCamera)
            _canvas.transform.rotation = _rotateToCamera;
    }
}
