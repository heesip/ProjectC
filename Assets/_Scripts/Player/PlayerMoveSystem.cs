using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem
{
    Rigidbody2D _rigid;
    Joystick _joystick;
    float _speed = 3f;
    Vector2 _direction;
    public Vector2 PlayerDirection => _direction;

    public void Initialize(Player player)
    {
        _joystick = UIManager.Instance.Joystick;
        _rigid = player.GetComponent<Rigidbody2D>();
    }

    public void PlayerMove()
    {
        _rigid.velocity = Vector2.zero;
        if (!_joystick.IsDrag)
        {
            return;
        }
        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        Vector2 nextVec = _direction.normalized * _speed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
    }

}
