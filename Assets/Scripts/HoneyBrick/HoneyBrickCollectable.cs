using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class HoneyBrickCollectable : MonoBehaviour
{
    public event UnityAction Taken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out HoneyBrickCollector collector))
        {
            CollectToBag(collector);

            collector.Put();

            Taken?.Invoke();
        }
    }

    private void CollectToBag(HoneyBrickCollector collector)
    {
         transform.SetParent(collector.transform);
        // transform.position = collector.BrickContainer.Places[collector.BrickCount].transform.position;
        // transform.rotation = collector.BrickContainer.Places[collector.BrickCount].transform.rotation;

        Vector3 pos = collector.BrickContainer.Places[collector.BrickCount].transform.position;
        Quaternion rot = collector.BrickContainer.Places[collector.BrickCount].transform.rotation;

      //  transform.DOJump(pos, 1, 1, 1);

    }

  
}
