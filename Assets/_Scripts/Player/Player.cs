using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerMoveSystem playerMoveSystem = new PlayerMoveSystem();
    PlayerAnimationSystem playerAnimationSystem = new PlayerAnimationSystem();
    public Vector2 Direction => playerMoveSystem.PlayerDirection;

    void Awake()
    {
        playerMoveSystem.Initialize(this);
        playerAnimationSystem.Initialize(this);
    }


    void FixedUpdate()
    {
        playerMoveSystem.PlayerMove();
        playerAnimationSystem.PlayerRunStance();
    }

    private void LateUpdate()
    {
        if (!UIManager.Instance.Joystick.IsDrag)
        {
            return;
        }
        playerAnimationSystem.PlayerTurn();
    }
}
