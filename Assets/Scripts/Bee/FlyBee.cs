using UnityEngine;
using DG.Tweening;

public class FlyBee : MonoBehaviour // rename
{
    [SerializeField] private Transform _startWaypoint;
    [SerializeField] private float _flyTime;
    [SerializeField] private float _timeToCollectHoney;

    private FinishWaypoint _finishWaypoint;

    private Spawner _spawner;

    private void Start()
    {
        _finishWaypoint = FindObjectOfType<FinishWaypoint>(); 

        _spawner = FindObjectOfType<Spawner>();

        transform.position = _startWaypoint.position;

        MoveBeeByPath();
    }

    private void MoveBeeByPath()
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
        if (other.gameObject.TryGetComponent(out FinishWaypoint hiveBeePointDelevery))
        {
            Debug.Log("ѕчела прилетела");

          //  _spawner.InstantiateHoneyBrick();
        }
    }
}