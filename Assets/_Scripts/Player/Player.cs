using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    [SerializeField] PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    [SerializeField] PlayerStatusSystem _playerStatusSystem = new PlayerStatusSystem();
    [SerializeField] PlayerIndicatorSystem _playerIndicatorSystem = new PlayerIndicatorSystem();
    public Vector2 MoveDirection => _playerMoveSystem.MoveDirection;
    public Vector3 AttackDirection => _playerIndicatorSystem.AttackDirection;

    public bool IsDead => _playerStatusSystem.IsDead;
    public bool IsLeft => _playerAnimationSystem.IsLeft;
    public bool IsAtropine => _playerStatusSystem.IsAtropine;

    public int Level => _playerStatusSystem.Level;
    public int Exp => _playerStatusSystem.Exp;
    public int[] NextExp => _playerStatusSystem.NextExp;
    public float MaxHealth => _playerStatusSystem.MaxHealth;
    public float Health => _playerStatusSystem.Health;
    public float Shield => _playerStatusSystem.Shield;
    public float MaxShield => _playerStatusSystem.MaxShield;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerAnimationSystem.Initialize(this);
        _playerStatusSystem.Initialize();
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
        _playerAnimationSystem.PlayerRunStance();

        if (!UIManager.Instance.Joystick.IsDrag)
        {
            return;
        }
        _playerAnimationSystem.PlayerTurn();
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
}
