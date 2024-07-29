using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThunderStroke : Singleton<ThunderStroke>
{
    [SerializeField] WeaponDataSO _weaponDataSO;

    TargetSystem _targetSystem = new TargetSystem();
    [SerializeField] Transform _randomTarget;
    Vector3 _playerPosition => Player.Instance.transform.position;
    WaitForSeconds _thunderStrokeCoolTime;
    WaitForSeconds _targetNullCoolTime;

    readonly int _maxLevel = 2;
    int _weaponLevel;

    float _damage;

    void Initialize()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
    }

    void FixedValue()
    {
        _targetNullCoolTime = _weaponDataSO.ThunderStrokeCoolTimes[_maxLevel];
    }

    public void UseWeapon()
    {
        if (gameObject.activeSelf)
        {
            LevelUp();
        }
        gameObject.SetActive(true);
    }
    void Awake()
    {
        Initialize();
        FixedValue();
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
        _thunderStrokeCoolTime = _weaponDataSO.ThunderStrokeCoolTimes[level];
        _damage = _weaponDataSO.ThunderDamages[level];
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
            return _weaponDataSO.AtropineThunderStrokeCoolTimes[_weaponLevel];
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
