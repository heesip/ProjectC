using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSystem
{
    Player _player;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public void Initialize(Player player)
    {
        _player = player;
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        animator = player.GetComponent<Animator>();
    }

    public void PlayerTurn()
    {
        spriteRenderer.flipX = _player.Direction.x < 0;
    }

    public void PlayerRunStance()
    {
        animator.SetBool("Run", UIManager.Instance.Joystick.IsDrag);
    }

}

