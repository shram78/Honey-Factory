using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DeliveryHoneyBrick : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private BoxCollider _deliveryArea;
    [SerializeField] private float _collectionDelay;

    private Coroutine CollectCoroutine;


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
        HoneyBrick honeyBrick = null;

        while (Physics.CheckBox(_deliveryArea.center, _deliveryArea.size))
        {
            PlaceHoneyBrick place = _container.Places.FirstOrDefault(place => place.IsAvailible);

            if (place != default)
            {
                honeyBrick = player.CollectorHoneyBrick.GiveBrick(place.transform.position, place.transform.rotation);
                Debug.Log("coruutine");

                if (honeyBrick != null)
                {
                    CollectableHoneyBrick collectableHoneyBrick = honeyBrick.GetComponent<CollectableHoneyBrick>();
                    collectableHoneyBrick.PutBrick(place.transform.position, place.transform.rotation);

                    place.Reserve(honeyBrick);
                }
            }

            yield return new WaitForSeconds(_collectionDelay);
        }
    }
}
