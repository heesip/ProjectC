using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Missile : Bullet
{
    protected override void OnStart()
    {
        transform.DOKill();
        _spriteRenderer.flipX = Player.Instance.IsLeft;
        _damage = 4;
    }

    public void Shoting(float nextVector_X, float duration)
    {
        transform.DOMoveX(nextVector_X, duration).SetEase(Ease.InCubic);
    }

}

