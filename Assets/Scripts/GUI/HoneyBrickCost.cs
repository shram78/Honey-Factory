using UnityEngine;
using TMPro;


public class HoneyBrickCost : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private TMP_Text _honeyBrickText;

    private void OnEnable()
    {
        _container.BrickAmountChanged += UpdateBrickStats;
    }

    private void OnDisable()
    {
        _container.BrickAmountChanged -= UpdateBrickStats;
    }

    private void UpdateBrickStats(int needHoneyBricksToBuy, int currentHoneyBricksCollected)
    {
        int honeyBrickToShow = needHoneyBricksToBuy - currentHoneyBricksCollected;
        // _honeyBrickText.text = $"{currentBricksAmount}/{maxbrickAmount}";
        _honeyBrickText.text = honeyBrickToShow.ToString();
    }
}
