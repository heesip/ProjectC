using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : RecycleObject
{
    Animator _animator;
    string _isPlay = "isAttack";
    Collider2D _coll;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _coll = GetComponent<Collider2D>();
        _coll.enabled = false;
    }

    void OnEnable()
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
        _coll.enabled = true;
        yield return new WaitForSeconds(0.01f);
        _coll.enabled = false;
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }





}

