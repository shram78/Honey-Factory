using UnityEngine;
using DG.Tweening;

public class WingFlap : MonoBehaviour
{
    [SerializeField] private GameObject _rightWing;
    [SerializeField] private GameObject _leftWing;

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rightWing.transform.DOLocalRotate(new Vector3(45, 0, 0), 0.05f).SetRelative());
        sequence.Append(_rightWing.transform.DOLocalRotate(new Vector3(-45, 0, 0), 0.05f).SetRelative());
        sequence.Append(_leftWing.transform.DOLocalRotate(new Vector3(45, 0, 0), 0.05f).SetRelative());
        sequence.Append(_leftWing.transform.DOLocalRotate(new Vector3(-45, 0, 0), 0.05f).SetRelative());

        sequence.SetLoops(-1);
    }
}
