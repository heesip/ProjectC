using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThunderStroke : Singleton<ThunderStroke>
{
    WeaponDataSO _weaponDataSO;

    TargetSystem _targetSystem = new TargetSystem();
    Transform _randomTarget;
    Vector3 _playerPosition => Player.Instance.transform.position;
    WaitForSeconds _coolTime;
    WaitForSeconds _coolTimeAtropine;
    WaitForSeconds _targetNullCoolTime;

    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    float _damage;

    public void UseWeapon()
    {
        LevelUp();
        gameObject.SetActive(true);
    }
    void Awake()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _targetNullCoolTime = new WaitForSeconds(_weaponDataSO.ThunderCoolTimes[_maxLevel]);
    }

    void OnEnable()
    {
        LevelValue(_level);
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void OnDisable()
    {
        StopCoHandle(_attackCoHandle);
    }

    void LevelUp()
    {
        gameObject.SetActive(false);
        if (_level < _maxLevel)
        {
            _level++;
        }
    }

    void LevelValue(int level)
    {
        _coolTime = new WaitForSeconds(_weaponDataSO.ThunderCoolTimes[level]);
        _coolTimeAtropine = new WaitForSeconds(_weaponDataSO.AtropineThunderCoolTimes[level]);
        _damage = _weaponDataSO.ThunderDamages[level];
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            for (int i = 0; i < _level; i++)
            {
                _randomTarget = _targetSystem.GetRandomTarget(_playerPosition);
                if (_randomTarget != null)
                {
                    Thunder thunder = FactoryManager.Instance.GetThunder();
                    thunder.AttackPoint(_randomTarget.position, _damage);
                    yield return new WaitForSeconds(.3f);
                }
                else
                {
                    yield return _targetNullCoolTime;
                }
            }
            yield return CheckAtropine();
        }
    }

    WaitForSeconds CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return _coolTimeAtropine;
        }
        else
        {
            return _coolTime;
        }
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }
}
