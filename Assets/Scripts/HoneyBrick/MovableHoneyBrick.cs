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
        float FlyingEffectValue = 1f;
        float FlightTime = 0.3f;
        float TimeToInsert = 0.5f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(FlyingEffectValue * (-1), FlightTime).SetRelative());
        sequence.Append(transform.DOMoveY(FlyingEffectValue, FlightTime).SetRelative());
        sequence.Append(transform.DOMove(targetPosition, FlightTime));
        sequence.Insert(TimeToInsert, transform.DORotate(rotationValueInPlace, FlightTime).SetRelative());
    }
}
