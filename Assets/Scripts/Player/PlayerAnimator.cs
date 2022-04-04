using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpawnScatePlace _spawnScate;

    private InputMouseComand _inputMouseComand;
    private const string _speed = "Speed";
    private bool _isHaveScate = false;

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
      // if (bool have scate)
     //   {
        _animator.SetFloat(_speed, 1);
      //  }
      //  else
        {

        }
    }

    private void OnHaveScate()
    {
        _isHaveScate = true;
      //  _animator.SetBool("IsHaveScate", true);
        _animator.SetTrigger("HaveScate");
    }
}
