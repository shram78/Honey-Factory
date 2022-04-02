using UnityEngine;
using TMPro;

public class HoneyBrickWidgetInScene : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private TMP_Text _honeyBrickText;
    [SerializeField] private SpawnFlowrbedPlace _spawnFlowrbedPlace;
    
    private void OnEnable()
    {
        _container.BrickAmountChanged += ShowCount;
        _spawnFlowrbedPlace.SpawnComplete += OnHide;
    }

    private void OnDisable()
    {
        _container.BrickAmountChanged -= ShowCount;
        _spawnFlowrbedPlace.SpawnComplete -= OnHide;
    }

    private void ShowCount(int needHoneyBricksToBuy, int currentHoneyBricksCollected)
    {
        int honeyBrickToShow = needHoneyBricksToBuy - currentHoneyBricksCollected;
        _honeyBrickText.text = honeyBrickToShow.ToString();
    }

    private void OnHide()
    {
        gameObject.SetActive(false);
    }
}
