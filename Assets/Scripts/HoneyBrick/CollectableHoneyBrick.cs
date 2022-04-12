using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CollectableHoneyBrick : MonoBehaviour
{
    public event UnityAction Taken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bag bag))
        {
            CollectToBag(bag);

            bag.Put();

            Taken?.Invoke();
        }
    }

    private void CollectToBag(Bag bag)
    {
        Vector3 shakeBrick = new Vector3(0f, 0f, 0.5f);

        transform.DOShakePosition(0.1f, shakeBrick);
        transform.SetParent(bag.transform);
        transform.position = bag.BrickContainer.Places[bag.BrickCount].transform.position;
        transform.rotation = bag.BrickContainer.Places[bag.BrickCount].transform.rotation;
    }
}
