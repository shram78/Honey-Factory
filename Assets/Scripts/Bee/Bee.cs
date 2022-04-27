using UnityEngine;
using DG.Tweening;

public class Bee : MonoBehaviour 
{
    [SerializeField] private Transform _startWaypoint;
    [SerializeField] private float _flyTime;
    [SerializeField] private float _timeToCollectHoney;
    [SerializeField] private GameObject _rightWing;
    [SerializeField] private GameObject _leftWing;

    private Vector3 _finishWaypoint;

    private void Start()
    {
        _finishWaypoint = new Vector3(0, 0.3f, 17); 

        transform.position = _startWaypoint.position;

        transform.DOLookAt(_finishWaypoint, 1f);

        MoveToHive();

        FlapWings();
    }

    private void MoveToHive()
    {
        float TimeToRotate = 0.1f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_finishWaypoint, _flyTime).SetEase(Ease.Flash).SetDelay(_timeToCollectHoney));
        sequence.Append(transform.DOLookAt(_startWaypoint.transform.position, TimeToRotate));
        sequence.Append(transform.DOMove(_startWaypoint.transform.position, _flyTime).SetEase(Ease.Flash));
        sequence.SetLoops(-1);
    }

    private void FlapWings()
    {
        Vector3 UpWingValue = new Vector3(45, 0, 0);
        Vector3 DownWingValue = new Vector3(-45, 0, 0);
        float TimeToFlap = 0.05f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rightWing.transform.DOLocalRotate(UpWingValue, TimeToFlap).SetRelative());
        sequence.Append(_rightWing.transform.DOLocalRotate(DownWingValue, TimeToFlap).SetRelative());
        sequence.Append(_leftWing.transform.DOLocalRotate(UpWingValue, TimeToFlap).SetRelative());
        sequence.Append(_leftWing.transform.DOLocalRotate(DownWingValue, TimeToFlap).SetRelative());
        sequence.SetLoops(-1);
    }
}