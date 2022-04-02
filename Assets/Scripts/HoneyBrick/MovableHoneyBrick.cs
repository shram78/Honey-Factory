using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MovableHoneyBrick : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private float _ySpeed = 3.5f;
    private float _zDistanceBeforeLanding = 2f;
    private Coroutine _flyCoroutine;

    public void InitFlyRoute(Vector3 targetPosition, Quaternion targetRotation)
    {
        _flyCoroutine = StartCoroutine(FlyAnimation(targetPosition, targetRotation));
    }

    public void MoveFromHive(Vector3 targetPosition)
    {
        transform.SetParent(null);

        Vector3 rotationValueInPlace = new Vector3(0, -90, -90);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(-1f, 0.3f).SetRelative());
        sequence.Append(transform.DOMoveY(1f, 0.3f).SetRelative());
        sequence.Append(transform.DOMove(targetPosition, 0.3f));
        sequence.Insert(0.5f, transform.DORotate(rotationValueInPlace, 0.3f).SetRelative());
    }


    private IEnumerator FlyAnimation(Vector3 targetPosition, Quaternion targetRotation)
    {
        transform.SetParent(null);

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.z - targetPosition.z) > _zDistanceBeforeLanding)
                transform.position = new Vector3(transform.position.x, transform.position.y + _ySpeed * Time.deltaTime, transform.position.z);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed);
            yield return null;
        }
    }

    //public void StopFlying()
    //{
    //    StopCoroutine(_flyCoroutine);
    //}
}
