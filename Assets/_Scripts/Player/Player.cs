using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Singleton<Player>
{
    [SerializeField] PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    [SerializeField] PlayerStatusSystem _playerStatusSystem = new PlayerStatusSystem();
    [SerializeField] PlayerIndicatorSystem _playerIndicatorSystem = new PlayerIndicatorSystem();
    public Vector2 MoveDirection => _playerMoveSystem.MoveDirection;
    public Vector3 AttackDirection => _playerIndicatorSystem.AttackDirection;

    public bool IsDead => _playerStatusSystem.IsDead;
    public bool IsLeft => _playerMoveSystem.IsLeft;
    public bool IsAtropine => _playerStatusSystem.IsAtropine;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerStatusSystem.Initialize();
    }

    void OnMove(InputValue inputValue)
    {
        _playerMoveSystem.OnMove(inputValue);
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

    void LateUpdate()
    {
        if (IsDead)
        {
            return;
        }
        _playerMoveSystem.PlayerRunStance();

        _playerMoveSystem.PlayerTurn();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (IsDead)
        {
            return;
        }

        if (!collision.collider.CompareTag(AllStrings.Enemy))
        {
            return;
        }
        _playerStatusSystem.OnDamage();
        _playerMoveSystem.VeleoCityZero();

    }

    public void Healing(float healingPoint, bool isAtropine)
    {
        _playerStatusSystem.Healing(healingPoint, isAtropine);
    }

    public void GetExpGem()
    {
        _playerStatusSystem.GetExpGem();
    }

    public void GetBuff()
    {
        _playerStatusSystem.GetBuff();
    }

    public void SocketOn()
    {
        _playerIndicatorSystem.SocketOn();
    }
}
