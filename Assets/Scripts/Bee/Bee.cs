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
        gameObject.GetComponentInParent<Transform>();

        _finishWaypoint = FindObjectOfType<PointBeeDelivery>(); 

        transform.position = _startWaypoint.position;

        transform.DOLookAt(_finishWaypoint.transform.position, 1f);

        MoveToHive();
    }

    private void MoveToHive()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_finishWaypoint.transform.position, _flyTime).SetEase(Ease.Flash).SetDelay(_timeToCollectHoney));
        sequence.Append(transform.DOLookAt(_startWaypoint.transform.position, 0.1f));
        sequence.Append(transform.DOMove(_startWaypoint.transform.position, _flyTime).SetEase(Ease.Flash));//.SetEase(Ease.Flash)) ;
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