using UnityEngine;

[RequireComponent(typeof(MouseButtonClicker))]

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpawnScatePlace _spawnScatePlace;

    private MouseButtonClicker _mouseButtonClicker;
    private const string _speed = "Speed";
    private const string _haveScate = "HaveScate";

    private void OnEnable()
    {
        _mouseButtonClicker = GetComponent<MouseButtonClicker>();

        _mouseButtonClicker.CursorPressed += PlayWalkAnimation;
        _mouseButtonClicker.CursorReleased += PlayIdleAnimation;
        _spawnScatePlace.GetScate += OnHaveScate;
    }
     
    private void PlayIdleAnimation()
    {
        _animator.SetFloat(_speed, 0);
    }

    private void PlayWalkAnimation()
    {
        _animator.SetFloat(_speed, 1);
    }

    private void OnHaveScate()
    {
        _animator.SetTrigger(_haveScate);
    }
    private void OnDisable()
    {
        _mouseButtonClicker.CursorPressed -= PlayWalkAnimation;
        _mouseButtonClicker.CursorReleased -= PlayIdleAnimation;
        _spawnScatePlace.GetScate -= OnHaveScate;
    }
}
