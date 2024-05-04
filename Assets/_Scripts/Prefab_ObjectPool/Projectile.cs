using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Projectile : RecycleObject
{
    SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _sprite.flipX = Player.Instance.IsLeft;
    }

    public void AttackPoint(Vector2 attackPoint)
    {
         transform.position = attackPoint;
    }
    public void Shot(float nextVector_X, float duration)
    {
        transform.DOMoveX(nextVector_X, duration).SetEase(Ease.InCubic);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        Remove();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Remove();
    }
    private void Remove()
    {
        transform.DOKill();
        Restore();
    }

}
