using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    public Vector2 Direction => _playerMoveSystem.PlayerDirection;

    [SerializeField] bool _isLive = true;
    public bool IsLive => _isLive;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerAnimationSystem.Initialize(this);
        _isLive = true;
    }


    void FixedUpdate()
    {
        _playerMoveSystem.PlayerMove();
        _playerAnimationSystem.PlayerRunStance();
    }

    private void LateUpdate()
    {
        if (!UIManager.Instance.Joystick.IsDrag)
        {
            return;
        }
        _playerAnimationSystem.PlayerTurn();
    }
}
