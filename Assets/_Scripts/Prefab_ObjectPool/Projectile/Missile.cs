using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Missile : Projectile
{
    new void OnEnable()
    {
        base.OnEnable();
        _sprite.flipX = Player.Instance.IsLeft;
    }

    public void Shot(float nextVector_X, float duration)
    {
        transform.DOMoveX(nextVector_X, duration).SetEase(Ease.InCubic);
    }

}

