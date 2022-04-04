using UnityEngine;
using TMPro;

public class HoneyBrickWidgetInScene : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private TMP_Text _honeyBrickText;
    [SerializeField] private SpawnInterractiveObjectPlace _spawnFlowrbedPlace;
    
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
}
