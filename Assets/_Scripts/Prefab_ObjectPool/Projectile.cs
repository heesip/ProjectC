using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Projectile : RecycleObject
{
    protected SpriteRenderer _sprite;

    protected void OnEnable()
    {
        StopCoHandle(_restoreCoHandle);
        _restoreCoHandle = StartCoroutine(RestoreCo());
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
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
        Restore();
    }

    protected void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }
    
    Coroutine _restoreCoHandle;

    IEnumerator RestoreCo()
    {
        yield return new WaitForSeconds(1.5f);
        Restore();
    }



}
