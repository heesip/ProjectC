using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Bullet : RecycleObject
{
    protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected bool _isProjectile;

    //TempCode
    protected float _duration = 1.5f;

    protected void OnEnable()
    {
        StopCoHandle(_restoreCoHandle);
        _restoreCoHandle = StartCoroutine(RestoreCo());
        OnStart();
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isProjectile = true;
    }

    protected virtual void OnStart() { }

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
        if (!_isProjectile)
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
        yield return new WaitForSeconds(_duration);
        Restore();
    }


}
