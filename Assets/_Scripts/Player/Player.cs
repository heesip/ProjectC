using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    [SerializeField] PlayerIndicatorSystem _playerIndicatorSystem = new PlayerIndicatorSystem();
    public Vector2 MoveDirection => _playerMoveSystem.MoveDirection;
    public Vector3 AttackDirection => _playerIndicatorSystem.AttackDirection;

    [SerializeField] bool _isDead;
    public bool IsDead => _isDead;

    [SerializeField] bool _isLeft;
    public bool IsLeft => _isLeft;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerAnimationSystem.Initialize(this);
        _isDead = false;
        _isLeft = false;

    }

    void FixedUpdate()
    {
        if (IsDead)
        {
            return;
        }
        _playerMoveSystem.PlayerMove();
        _playerIndicatorSystem.IndicatorMove(MoveDirection);
    }

    private void LateUpdate()
    {
        if (IsDead)
        {
            return;
        }
        _playerAnimationSystem.PlayerRunStance();

        if (!UIManager.Instance.Joystick.IsDrag)
        {
            return;
        }
        _isLeft = _playerAnimationSystem.PlayerTurn();
    }
}
