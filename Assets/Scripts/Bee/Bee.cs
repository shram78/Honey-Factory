using UnityEngine;
using DG.Tweening;

public class Bee : MonoBehaviour 
{
    [SerializeField] private Transform _startWaypoint;
    [SerializeField] private float _flyTime;
    [SerializeField] private float _timeToCollectHoney;
    [SerializeField] private GameObject _rightWing;
    [SerializeField] private GameObject _leftWing;

    private PointBeeDelivery _finishWaypoint;

    private void Start()
    {
        _finishWaypoint = FindObjectOfType<PointBeeDelivery>(); 

        transform.position = _startWaypoint.position;

        transform.DOLookAt(_finishWaypoint.transform.position, 1f);

        MoveToHive();

        FlapWings();
    }

    private void MoveToHive()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_finishWaypoint.transform.position, _flyTime).SetEase(Ease.Flash).SetDelay(_timeToCollectHoney));
        sequence.Append(transform.DOLookAt(_startWaypoint.transform.position, 0.1f));
        sequence.Append(transform.DOMove(_startWaypoint.transform.position, _flyTime).SetEase(Ease.Flash));
        sequence.SetLoops(-1);
    }

    private void FlapWings()
    {
        Vector3 UpWingValue = new Vector3(45, 0, 0);
        Vector3 DownWingValue = new Vector3(-45, 0, 0);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rightWing.transform.DOLocalRotate(UpWingValue, 0.05f).SetRelative());
        sequence.Append(_rightWing.transform.DOLocalRotate(DownWingValue, 0.05f).SetRelative());
        sequence.Append(_leftWing.transform.DOLocalRotate(UpWingValue, 0.05f).SetRelative());
        sequence.Append(_leftWing.transform.DOLocalRotate(DownWingValue, 0.05f).SetRelative());
        sequence.SetLoops(-1);
    }
}