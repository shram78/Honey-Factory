using UnityEngine;
using DG.Tweening;

//[RequireComponent] ПоинтДелевири

public class Bee : MonoBehaviour 
{
    [SerializeField] private Transform _startWaypoint;
    [SerializeField] private float _flyTime;
    [SerializeField] private float _timeToCollectHoney;

    private PointBeeDelivery _finishWaypoint;

    private void Start()
    {
        _finishWaypoint = FindObjectOfType<PointBeeDelivery>(); 

        transform.position = _startWaypoint.position;

        MoveToHive();
    }

    private void MoveToHive()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLookAt(_finishWaypoint.transform.position, 0));
        sequence.Append(transform.DOMove(_finishWaypoint.transform.position, _flyTime).SetEase(Ease.Flash).SetDelay(_timeToCollectHoney));
        sequence.Append(transform.DOLookAt(_startWaypoint.position, 0));
        sequence.Append(transform.DOMove(_startWaypoint.position, _flyTime).SetEase(Ease.Flash));
        sequence.SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.TryGetComponent(out PointBeeDelivery hiveBeePointDelevery))
        //{
        //    Debug.Log("Пчела прилетела");

        //  //  _spawner.InstantiateHoneyBrick();
        //}
    }
}