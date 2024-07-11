using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStroke : Weapon
{
    [SerializeField] ThunderStrokeDataSO _thunderStrokeDataSO;

    TargetSystem _targetSystem = new TargetSystem();
    [SerializeField] Transform _randomTarget;
    Vector3 _playerPosition => Player.Instance.transform.position;
    WaitForSeconds _thunderStrokeCoolTime;
    WaitForSeconds _targetNullCoolTime;


    protected override void Initialize()
    {
        _thunderStrokeDataSO = GameDataManager.Instance.GetThunderStrokeDataSO();
    }

    protected override void FixedValue()
    {
        _targetNullCoolTime = _thunderStrokeDataSO.ThunderStrokeCoolTimes[_maxLevel];
    }

    public override void UseWeapon()
    {
        if (gameObject.activeSelf)
        {
            LevelUp();
        }
        gameObject.SetActive(true);
    }

    void LevelUp()
    {
        gameObject.SetActive(false);
        if (_weaponLevel < _maxLevel)
        {
            _weaponLevel++;
        }
    }

    void LevelValue(int level)
    {
        _thunderStrokeCoolTime = _thunderStrokeDataSO.ThunderStrokeCoolTimes[level];
        _damage = _thunderStrokeDataSO.ThunderDamages[level];
    }

    void OnEnable()
    {
        LevelValue(_weaponLevel);
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void OnDisable()
    {
        StopCoHandle(_attackCoHandle);
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            _randomTarget = _targetSystem.GetRandomTarget(_playerPosition);
            if (_randomTarget != null)
            {
                Thunder thunder = FactoryManager.Instance.GetThunder();
                thunder.AttackPoint(_randomTarget.position, _damage);
                yield return CheckAtropine();
            }
            else
            {
                yield return _targetNullCoolTime;
            }

        }
    }

    WaitForSeconds CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return _thunderStrokeDataSO.AtropineThunderStrokeCoolTimes[_weaponLevel];
        }
        else
        {
            return _thunderStrokeCoolTime;
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
