using System.Collections;
using UnityEngine;
using DG.Tweening;


public class HoneyBrickMovable : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;


    public void InitFlyRoute(Vector3 targetPosition, Quaternion targetRotation)
    {
        MoveHoneyBrickByPath(targetPosition, targetRotation);
    }

    private void MoveHoneyBrickByPath(Vector3 targetPosition, Quaternion targetRotation)
    {
        Sequence sequence = DOTween.Sequence();

        
        sequence.Append(transform.DOLocalMoveY(1.5f, 0.5f).SetDelay(0.5f));
        //sequence.Append(transform.DOLocalRotate(targetRotation.eulerAngles, 1));

        sequence.Append(transform.DOLocalRotate(targetRotation.eulerAngles, 1));

        sequence.Insert(1, transform.DOMove(targetPosition, 1));
    } 
}