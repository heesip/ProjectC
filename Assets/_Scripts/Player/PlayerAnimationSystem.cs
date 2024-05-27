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

    public bool PlayerTurn()
    {
        _spriteRenderer.flipX = _player.MoveDirection.x < 0;
        return _spriteRenderer.flipX;
    }

    public void PlayerRunStance()
    {
        _animator.SetBool("Run", UIManager.Instance.Joystick.IsDrag);
    }

}

