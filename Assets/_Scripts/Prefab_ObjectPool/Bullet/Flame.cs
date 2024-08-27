using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : Bullet
{
    Collider2D _collider;
    #region FlameInfo
    WaitForSeconds _attackDelay = new WaitForSeconds(0.5f);
    float _flameDamage = 3;
    float _flameDuration = 10;
    float _atorpineFlameDamage = 9999999;
    #endregion
    protected override void OnStart()
    {
        FlameSetting();
        _collider = GetComponent<Collider2D>();
        _isProjectile = false;
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        AudioManager.Instance.PlaySFX(SFXType.Flame);
        while (true)
        {
            _collider.enabled = !_collider.enabled;
            yield return _attackDelay;
        }
    }

    void OnDisable()
    {
        StopCoHandle(_attackCoHandle);
        _collider.enabled = true;
    }

    void FlameSetting()
    {
        _damage = CheckAtropine();
        _duration = _flameDuration;
    }

    float CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return _atorpineFlameDamage;
        }
        else
        {
            return _flameDamage;
        }
    }

}
