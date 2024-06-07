using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnimationSystem
{
    Player _player;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    [SerializeField] bool _isLeft;
    public bool IsLeft => _isLeft;


    public void Initialize(Player player)
    {
        _player = player;
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
        _animator = player.GetComponent<Animator>();
    }

    public void PlayerTurn()
    {
        _spriteRenderer.flipX = _player.MoveDirection.x < 0;
        _isLeft = _spriteRenderer.flipX;
    }

    public void PlayerRunStance()
    {
        _animator.SetBool(AllStrings.Run, UIManager.Instance.Joystick.IsDrag);
    }

}

