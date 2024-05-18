using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Missile : Projectile
{
    private void OnEnable()
    {
        _sprite.flipX = Player.Instance.IsLeft;
    }

    public void Shot(float nextVector_X, float duration)
    {
        transform.DOMoveX(nextVector_X, duration).SetEase(Ease.InCubic);
    }


}

