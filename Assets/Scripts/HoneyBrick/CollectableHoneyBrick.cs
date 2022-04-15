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
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveZ(-0.5f, 0.05f).SetRelative());
        sequence.Append(transform.DOLocalMoveZ(0.5f, 0.05f).SetRelative());

        transform.SetParent(bag.transform);
        transform.position = bag.BrickContainer.Places[bag.BrickCount].transform.position;
        transform.rotation = bag.BrickContainer.Places[bag.BrickCount].transform.rotation;
    }
}
