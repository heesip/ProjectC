using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Missile : Projectile
{
    public void Shot(float nextVector_X, float duration)
    {
        transform.DOMoveX(nextVector_X, duration).SetEase(Ease.InCubic);
    }

}

