using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using DG.Tweening;


public class DeliveryHoneyBrick : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private BoxCollider _deliveryArea;
    [SerializeField] private float _collectionDelay;

    private Coroutine CollectCoroutine;

    public event UnityAction<HoneyBrick> Collected;//


    //
    private void OnEnable()
    {
        Collected += OnBrickCollected;
    }

    private void OnDisable()
    {
        Collected -= OnBrickCollected;
    }
    //


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            CollectCoroutine = StartCoroutine(CollectFrom(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            if (CollectCoroutine != null)
                StopCoroutine(CollectCoroutine);
        }
    }

    private IEnumerator CollectFrom(Player player)
    {
        HoneyBrick brick = null;

        while (Physics.CheckBox(_deliveryArea.center, _deliveryArea.size))
        {
            PlaceHoneyBrick place = _container.Places.FirstOrDefault(place => place.IsAvailible);

            if (place != default)
            {
                brick = player.Bag.GiveBrick(place.transform.position, place.transform.rotation);

                if (brick != null)
                {
                    MovableHoneyBrick fly = brick.GetComponent<MovableHoneyBrick>();
                    fly.InitFlyRoute(place.transform.position, place.transform.rotation);

                    place.Reserve(brick);

                    Collected?.Invoke(brick);
                }
            }

            yield return new WaitForSeconds(_collectionDelay);
        }
    }


    private void OnBrickCollected(HoneyBrick brick)
    {
        _container.AddBrick();
    }
}
