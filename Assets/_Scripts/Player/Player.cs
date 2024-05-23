using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    [SerializeField] PlayerSocketSystem _playerSocketSystem = new PlayerSocketSystem();
    PlayerAttackSystem _playerAttackSystem = new PlayerAttackSystem();
    public Vector2 Direction => _playerMoveSystem.PlayerDirection;
    Vector2 _moveDirection;
    [SerializeField] bool _isLive;
    public bool IsLive => _isLive;

    [SerializeField] bool _isLeft;
    public bool IsLeft => _isLeft;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerAnimationSystem.Initialize(this);
       _playerAttackSystem.Initialize(this);
        _isLive = true;
        _isLeft = false;

    }

    void FixedUpdate()
    {
        _playerMoveSystem.PlayerMove();
        _playerSocketSystem.IndicatorMove(Direction);
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
