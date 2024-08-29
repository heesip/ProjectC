using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class NinjaStarBox : Singleton<NinjaStarBox>
{
    WeaponDataSO _weaponDataSO;
    TargetSystem _targetSystem = new TargetSystem();
    Transform _nearestTarget;
    Vector3 _playerPosition => Player.Instance.transform.position;
    Vector3 _attackDirection => Player.Instance.AttackDirection;
    Vector3 _projectileRotate;
    float _duration;

    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    float _damage;
    float _damageAtropine;
    float _speed;
    WaitForSeconds _coolTime;
    WaitForSeconds _coolTimeAtropine;

    public void UseWeapon()
    {
        LevelUp();
        gameObject.SetActive(true);
    }
    void Awake()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _projectileRotate = _weaponDataSO.ProjectileRotate;
        _speed = _weaponDataSO.NinjaStarSpeed;
        _duration = _weaponDataSO.NinjaStarDuration;
    }

    void OnEnable()
    {
        LevelValue(_level);
        _throwingNinjaStarCoHandle = StartCoroutine(ThrowingNinjaStarCo());
    }

    void OnDisable()
    {
        StopCoHandle(_throwingNinjaStarCoHandle);
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
        _coolTime = new WaitForSeconds(_weaponDataSO.NinjaStarCoolTimes[level]);
        _coolTimeAtropine = new WaitForSeconds(_weaponDataSO.AtropineNinjaStarCoolTimes[level]);
        _damage = _weaponDataSO.NinjaStarDamages[level];
        _damageAtropine = _weaponDataSO.AtroPineNinjaStarDamages[level];
    }

    Coroutine _throwingNinjaStarCoHandle;
    IEnumerator ThrowingNinjaStarCo()
    {
        while (true)
        {
            ThrowingNinjaStar(CheckAtropine().damage);
            yield return CheckAtropine().coolTime;
        }
    }

    (WaitForSeconds coolTime, float damage) CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return (_coolTimeAtropine, _damageAtropine);
        }
        else
        {
            return (_coolTime, _damage);
        }
    }

    void ThrowingNinjaStar(float ninjaStarDamage)
    {
        _nearestTarget = _targetSystem.GetNearestTarget(_playerPosition);
        NinjaStar ninjaStar = FactoryManager.Instance.GetNinjaStar();
        ninjaStar.Initiazlie(ninjaStarDamage, _speed, _duration, _projectileRotate);
        ninjaStar.AttackPoint(transform.position);
        if (_nearestTarget != null)
        {
            ninjaStar.Throw(Targeting());
        }
        AudioManager.Instance.PlaySFX(SFXType.Throwing);
        ninjaStar.Throw(_attackDirection);
    }

    Vector3 Targeting()
    {
        Vector3 direction = (_nearestTarget.position - _playerPosition).normalized;
        return direction;
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }
}
