using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SpawnScatePlace : SpawnInterractiveObjectPlace
{
    [SerializeField] private Player _player;

    public event UnityAction GetScate;

    protected override void CreateSpawnEffect(GameObject gameObject)
    {
         Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);
        
        gameObject.transform.DOPunchScale(targetScale, 0.2f, 0, 1);

        SetParrent(gameObject);
    }

    private void SetParrent(GameObject gameObject)
    {
        gameObject.transform.SetParent(_player.transform);  

        GetScate?.Invoke();
    }
}