using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem
{
    Rigidbody2D _rigidbody;
    Joystick _joystick;
    float _speed = 3f;
    Vector2 _moveDirection;
    public Vector2 MoveDirection => _moveDirection;

    public void Initialize(Player player)
    {
        _joystick = UIManager.Instance.Joystick;
        _rigidbody = player.GetComponent<Rigidbody2D>();
    }

    public void PlayerMove()
    {
        _rigidbody.velocity = Vector2.zero;
        if (!_joystick.IsDrag)
        {
            return;
        }
        _moveDirection = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        Vector2 nextVec = _moveDirection.normalized * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

}
