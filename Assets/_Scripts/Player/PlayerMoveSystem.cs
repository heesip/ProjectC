using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveSystem
{
    Player _player;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    [SerializeField] bool _isLeft;
    public bool IsLeft => _isLeft;

    Rigidbody2D _rigidbody;
    Joystick _joystick;
    float _speed = 3f;
    Vector2 _moveDirection;
    public Vector2 MoveDirection => _moveDirection;

    public void Initialize(Player player)
    {
        _player = player;
        _joystick = UIManager.Instance.Joystick;
        _rigidbody = player.GetComponent<Rigidbody2D>();
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
        _animator = player.GetComponent<Animator>();
    }

    public void PlayerMove()
    {
        if (GameManager.Instance.IsKeyboard)
        {
            MoveKeyboard();

        }
        else
        {
            MoveJoyStick();
        }
    }

    public void MoveJoyStick()
    {
        if (!_joystick.IsDrag)
        {
            return;
        }
        _rigidbody.velocity = Vector2.zero;
        _moveDirection = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        Vector2 nextVec = _moveDirection.normalized * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

    public void MoveKeyboard()
    {
        _rigidbody.velocity = Vector2.zero;
        Vector2 nextVec = _moveDirection.normalized * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }


    public void PlayerTurn()
    {
        if (_moveDirection.x != 0)
        {
            _spriteRenderer.flipX = _player.MoveDirection.x < 0;
        }
        _isLeft = _spriteRenderer.flipX;
    }

    public void PlayerRunStance()
    {
        if (GameManager.Instance.IsKeyboard)
        {
            _animator.SetFloat(AllStrings.Run_Key, _moveDirection.magnitude);
        }
        else
        {
            _animator.SetBool(AllStrings.Run_Joy, _joystick.IsDrag);
        }
    }

    public void OnMove(InputValue inputValue)
    {
        _moveDirection = inputValue.Get<Vector2>();
    }
}
