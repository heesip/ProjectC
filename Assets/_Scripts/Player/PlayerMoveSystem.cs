using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveSystem
{
    Player _player;
    Rigidbody2D _rigidbody;
    float _speed = 3f;
    Vector2 _moveDirection;
    public Vector2 MoveDirection => _moveDirection;

    SpriteRenderer _spriteRenderer;
    Animator _animator;
    [SerializeField] bool _isLeft;
    public bool IsLeft => _isLeft;

    public void Initialize(Player player)
    {
        _player = player;
        _rigidbody = player.GetComponent<Rigidbody2D>();
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
        _animator = player.GetComponent<Animator>();
    }

    public void PlayerMove()
    {
        InputSystemMove();
    }

    public void OnMove(InputValue inputValue)
    {
        _moveDirection = inputValue.Get<Vector2>();
    }

    public void PlayerTurn()
    {
        if (_moveDirection.x != 0)
        {
            _spriteRenderer.flipX = _player.MoveDirection.x < 0;
            _isLeft = _spriteRenderer.flipX;
        }
    }

    public void PlayerRunStance()
    {
        _animator.SetFloat(AllStrings.Run, _moveDirection.magnitude);
    }

    void InputSystemMove()
    {
        _rigidbody.velocity = Vector2.zero;
        Vector2 nextVec = _moveDirection.normalized * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }
}
