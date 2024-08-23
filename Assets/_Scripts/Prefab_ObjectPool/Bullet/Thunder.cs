using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Bullet
{
    float _myVolume = 0.2f;
    Animator _animator;
    Collider2D _collider;


    protected override void OnStart()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
        _isProjectile = false;
    }

    void OnDisable()
    {
        _animator.SetBool(AllStrings.Attack, false);
        StopAttackCo();
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        _animator.SetBool(AllStrings.Attack, true);
        AudioManager.Instance.PlaySFX(SFXType.Thunder, _myVolume);
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

