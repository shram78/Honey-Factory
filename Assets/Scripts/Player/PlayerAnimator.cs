using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpawnScatePlace _spawnScate;

    private InputMouseComand _inputMouseComand;
    private const string _speed = "Speed";
    private const string _haveScate = "HaveScate";


    private void OnEnable()
    {
        _inputMouseComand = GetComponent<InputMouseComand>();

        _inputMouseComand.OnCursorPressed += PlayWalkAnimation;
        _inputMouseComand.OnCursorReleased += PlayIdleAnimation;
        _spawnScate.GetScate += OnHaveScate;
    }

    private void OnDisable()
    {
        _inputMouseComand.OnCursorPressed -= PlayWalkAnimation;
        _inputMouseComand.OnCursorReleased -= PlayIdleAnimation;
        _spawnScate.GetScate -= OnHaveScate;
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
}
