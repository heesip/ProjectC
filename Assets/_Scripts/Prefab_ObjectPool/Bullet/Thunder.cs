using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Bullet
{
    Animator _animator;
    Collider2D _collider;

    //TempCode
    readonly string _isPlay = "isAttack";

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
        _isProjectile = false;
    }

    protected override void OnStart()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void OnDisable()
    {
        _animator.SetBool(_isPlay, false);
        StopAttackCo();
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        _animator.SetBool(_isPlay, true);
        yield return null;
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }




}

