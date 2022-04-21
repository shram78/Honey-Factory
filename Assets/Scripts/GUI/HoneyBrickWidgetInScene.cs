using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]

public class HoneyBrickWidgetInScene : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private TMP_Text _honeyBrickText;
    [SerializeField] private SpawnInterractiveObjectPlace _spawnInterractiveObjectPlace;
    [SerializeField] private GameObject _panelWidget;
    [SerializeField] private DeliveryHoneyBrick _deliveryHoneyBrick;

    private RectTransform _rectTransfromWidget;

    private void OnEnable()
    {
        _container.BrickAmountChanged += OnShowCount;
        _spawnInterractiveObjectPlace.SpawnComplete += OnHide;
        _deliveryHoneyBrick.EnterArea += OnScaleUp;
        _deliveryHoneyBrick.ExitArea += OnScaleDown;
    }

    private void Start()
    {
        _rectTransfromWidget = _panelWidget.GetComponent<RectTransform>();
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
        float InteractionValue = 1.5f;
        float TimeToChange = 0.2f;

        _rectTransfromWidget.transform.DOScale(InteractionValue, TimeToChange); 
    }

    private void OnScaleDown()
    {
        float StandartValue = 1f;
        float TimeToChange = 0.2f;

        _rectTransfromWidget.transform.DOScale(StandartValue, TimeToChange); 
    }

    private void OnHide()
    {
        gameObject.SetActive(false);
    }
}
