using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem _playerMoveSystem = new PlayerMoveSystem();
    [SerializeField] PlayerAnimationSystem _playerAnimationSystem = new PlayerAnimationSystem();
    [SerializeField] PlayerInfoSystem _playerInfoSystem = new PlayerInfoSystem();
    [SerializeField] PlayerIndicatorSystem _playerIndicatorSystem = new PlayerIndicatorSystem();
    public Vector2 MoveDirection => _playerMoveSystem.MoveDirection;
    public Vector3 AttackDirection => _playerIndicatorSystem.AttackDirection;

    public bool IsDead => _playerInfoSystem.IsDead;
    public bool IsLeft => _playerAnimationSystem.IsLeft;

    void Awake()
    {
        _playerMoveSystem.Initialize(this);
        _playerAnimationSystem.Initialize(this);
        _playerInfoSystem.Initialize();

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

        if (!collision.collider.CompareTag("Enemy"))
        {
            return;
        }
        _playerInfoSystem.OnDamage();

    }

    public void GetPotion(PotionType potionType)
    {
        _playerInfoSystem.GetPotion(potionType);
    }
}
