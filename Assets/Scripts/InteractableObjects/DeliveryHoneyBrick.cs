using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class DeliveryHoneyBrick : MonoBehaviour
{
    [SerializeField] private ContainerHoneyBrick _container;
    [SerializeField] private BoxCollider _deliveryArea;
    [SerializeField] private float _collectionDelay;

    private Coroutine CollectCoroutine;

    public event UnityAction<HoneyBrick> Collected;
    public event UnityAction EnterArea;
    public event UnityAction ExitArea;

    private void OnEnable()
    {
        Collected += OnBrickCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            EnterArea?.Invoke();

            CollectCoroutine = StartCoroutine(CollectFrom(player));
        }
    }

    private void OnDisable()
    {
        Collected -= OnBrickCollected;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            ExitArea?.Invoke();

            if (CollectCoroutine != null)
                StopCoroutine(CollectCoroutine);
        }
    }

    private IEnumerator CollectFrom(Player player)
    {
        HoneyBrick brick = null;

        while (Physics.CheckBox(_deliveryArea.center, _deliveryArea.size))
        {
            CollectedAll();

            PlaceHoneyBrick place = _container.Places.FirstOrDefault(place => place.IsAvailible);

            if (place != default)
            {
                brick = player.Bag.SellBrick();

                if (brick != null)
                {
                    MovableHoneyBrick movable = brick.GetComponent<MovableHoneyBrick>();

                    movable.Unload();

                    place.Reserve(brick);

                    Collected?.Invoke(brick);
                }
            }
            yield return new WaitForSeconds(_collectionDelay);
        }
    }

    private void OnBrickCollected(HoneyBrick brick)
    {
        _container.AddBrick();
    }

    public bool CollectedAll()
    {
        PlaceHoneyBrick brickPlace = _container.Places.FirstOrDefault(place => place.IsAvailible);

        return (brickPlace == null);
    }
}
