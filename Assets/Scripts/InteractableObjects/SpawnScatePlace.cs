using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SpawnScatePlace : SpawnInterractiveObjectPlace
{
    [SerializeField] private Player _player;

    public event UnityAction GetScate;

    protected override void CreateSpawnEffect(GameObject gameObject)
    {
        Vector3 targetScale = new Vector3(0.07f, 0.07f, 0.07f);
        float TimeEffect = 0.7f;

        gameObject.transform.DOPunchScale(targetScale, TimeEffect, 0, 1);

        _player.StandOnScate();

        SetParrent(gameObject);
    }

    private void SetParrent(GameObject gameObject)
    {
        gameObject.transform.SetParent(_player.transform);

        GetScate?.Invoke();
    }
}