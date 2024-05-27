using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    [SerializeField] PlayerAttackSystem _playerAttackSystem = new PlayerAttackSystem();
    public Vector2 MoveDirection => _playerMoveSystem.MoveDirection;
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
        _playerAttackSystem.IndicatorMove(MoveDirection);
    }

    private void LateUpdate()
    {
        _playerAnimationSystem.PlayerRunStance();
        if (!UIManager.Instance.Joystick.IsDrag)
        {
            return;
        }
        _isLeft = _playerAnimationSystem.PlayerTurn();
    }
}
