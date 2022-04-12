using UnityEngine;
using DG.Tweening;

public class MovableHoneyBrick : MonoBehaviour
{
    public void Unload()
    {
        Destroy(gameObject);
    }

    public void MoveFromHive(Vector3 targetPosition)
    {
        Vector3 rotationValueInPlace = new Vector3(0, -90, -90);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(-1f, 0.3f).SetRelative());
        sequence.Append(transform.DOMoveY(1f, 0.3f).SetRelative());
        sequence.Append(transform.DOMove(targetPosition, 0.3f));
        sequence.Insert(0.5f, transform.DORotate(rotationValueInPlace, 0.3f).SetRelative());
    }
}
