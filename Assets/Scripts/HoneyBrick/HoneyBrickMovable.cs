using System.Collections;
using UnityEngine;
using DG.Tweening;


public class HoneyBrickMovable : MonoBehaviour
{
    public void InitFlyRoute(Vector3 targetPosition, Quaternion targetRotation)
    {
        MoveHoneyBrickByPath(targetPosition, targetRotation);
    }

    private void MoveHoneyBrickByPath(Vector3 targetPosition, Quaternion targetRotation)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMoveX(-1f, 0.3f).SetRelative());
        sequence.Append(transform.DOLocalMoveY(1.5f, 0.5f).SetEase(Ease.Flash).SetDelay(0.1f).SetRelative());
        sequence.Append(transform.DOLocalRotate(targetRotation.eulerAngles, 0.5f));
        sequence.Insert(1, transform.DOMove(targetPosition, 0.5f).SetEase(Ease.Flash));
    }
}