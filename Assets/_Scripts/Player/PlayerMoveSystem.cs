using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem
{
    Player _player;
    Joystick _joystick;
    float _speed = 3f;
    Vector2 _direction;
    public Vector2 PlayerDirection => _direction;

    public void Initialize(Player player)
    {
        _player = player;
        _joystick = UIManager.Instance.Joystick;
    }

    public void PlayerMove()
    {
        if (!_joystick.IsDrag)  
        {
            return;
        }
        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        _player.transform.position += (Vector3)_direction.normalized * _speed * Time.fixedDeltaTime;

    }

}
