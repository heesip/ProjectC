using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Projectile : RecycleObject
{
   protected SpriteRenderer _sprite;
    [SerializeField] int _id;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        switch (_id)
        {
            case 0:
                _sprite.flipX = Player.Instance.IsLeft;
                break;
            default:
                break;
        }
    }

    

    public void AttackPoint(Vector2 attackPoint)
    {
        transform.position = attackPoint;
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
