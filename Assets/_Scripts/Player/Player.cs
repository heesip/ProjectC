using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    public Vector2 Direction => _playerMoveSystem.PlayerDirection;

    [SerializeField] bool _isLive;
    public bool IsLive => _isLive;

    [SerializeField] bool _isLeft;
    public bool IsLeft => _isLeft;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerAnimationSystem.Initialize(this);
        _isLive = true;
        _isLeft = false;
    }


    void FixedUpdate()
    {
        _playerMoveSystem.PlayerMove();
    }

    private void LateUpdate()
    {
        _playerAnimationSystem.PlayerRunStance();
        if (!UIManager.Instance.Joystick.IsDrag)
        {
            return;
        }
        _playerAnimationSystem.PlayerTurn(out _isLeft);
    }
}
