using UnityEngine;
using TMPro;

public class PlayerHoneyWidget : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private TMP_Text _honeyBrickText;

    private void OnEnable()
    {
        _bag.BrickCollected += OnShow;
        _bag.BrickSell += OnShow;
    }

    private void OnDisable()
    {
        _bag.BrickCollected -= OnShow;
        _bag.BrickSell -= OnShow;
    }

    private void OnShow(int currentHoney)
    {
        _honeyBrickText.text = currentHoney.ToString();
    }
}