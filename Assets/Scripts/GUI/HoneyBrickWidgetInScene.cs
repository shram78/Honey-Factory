using UnityEngine;
using TMPro;
using DG.Tweening;


public class HoneyBrickWidgetInScene : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private TMP_Text _honeyBrickText;
    [SerializeField] private SpawnInterractiveObjectPlace _spawnInterractiveObjectPlace;
    [SerializeField] private GameObject _panelWidget;
    [SerializeField] private DeliveryHoneyBrick _deliveryHoneyBrick;

    private Quaternion _rotateToCamera;
    private RectTransform _rectTransfromWidget;

    private void Start()
    {
        _rectTransfromWidget = _panelWidget.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _container.BrickAmountChanged += OnShowCount;
        _spawnInterractiveObjectPlace.SpawnComplete += OnHide;
        _deliveryHoneyBrick.EnterArea += OnScaleUp;
        _deliveryHoneyBrick.ExitArea += OnScaleDown;
    }

    private void OnDisable()
    {
        _container.BrickAmountChanged -= OnShowCount;
        _spawnInterractiveObjectPlace.SpawnComplete -= OnHide;
        _deliveryHoneyBrick.EnterArea -= OnScaleUp;
        _deliveryHoneyBrick.ExitArea -= OnScaleDown;
    }

    private void OnShowCount(int needHoneyBricksToBuy, int currentHoneyBricksCollected)
    {
        int honeyBrickToShow = needHoneyBricksToBuy - currentHoneyBricksCollected;
        _honeyBrickText.text = honeyBrickToShow.ToString();
    }

    private void OnScaleUp()
    {
        _rectTransfromWidget.transform.DOScale(1.5f, 0.2f); 
    }

    private void OnScaleDown()
    {
        _rectTransfromWidget.transform.DOScale(1f, 0.2f); 
    }

    private void OnHide()
    {
        gameObject.SetActive(false);
    }
}
