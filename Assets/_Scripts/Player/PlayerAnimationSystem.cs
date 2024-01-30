using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSystem
{
    Player _player;
    SpriteRenderer _spriteRenderer;
    Animator _animator;

    public void Initialize(Player player)
    {
        _player = player;
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
        _animator = player.GetComponent<Animator>();
    }

    public void PlayerTurn()
    {
        _spriteRenderer.flipX = _player.Direction.x < 0;
    }

    public void PlayerRunStance()
    {
        _animator.SetBool("Run", UIManager.Instance.Joystick.IsDrag);
    }

}

