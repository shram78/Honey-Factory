using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CollectableHoneyBrick : MonoBehaviour
{
    public event UnityAction Taken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CollectorHoneyBrick collector))
        {
            CollectToBag(collector);

            collector.Put();

            Taken?.Invoke(); 
        }
    }

    private void CollectToBag(CollectorHoneyBrick collector)
    {
        Vector3 positionBrickOnPlayers = collector.BrickContainer.Places[collector.BrickCount].transform.position;
        Vector3 rotationBrickToPlayer = new Vector3(0,-90,0);

        transform.SetParent(collector.transform);
        transform.DOMove(positionBrickOnPlayers, 0f);
        transform.DOLocalRotate(rotationBrickToPlayer, 0f);
    }

    public void Collect(Vector3 targetPosition)
    {
        MoveToPlayer(targetPosition);
    }

    private void MoveToPlayer(Vector3 targetPosition)
    {
        Vector3 rotationValueInPlace = new Vector3(0, -90, -90);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(-1f, 0.3f).SetRelative());
        sequence.Append(transform.DOMoveY(1f, 0.3f).SetRelative());
        sequence.Append(transform.DOMove(targetPosition, 0.3f));
        sequence.Insert(0.5f, transform.DORotate(rotationValueInPlace, 0.3f).SetRelative());
    }

}
