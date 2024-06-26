using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NinjaStarBox : Weapon
{
    [SerializeField] NinjaStarBoxDataSO _ninjaStarBoxDataSO;
    Vector3 _attackDirection => Player.Instance.AttackDirection;
    Vector3 _projectileRotate;
    float _duration;

    protected override void Initialize()
    {
        _ninjaStarBoxDataSO = GameDataManager.Instance.GetNinjaStarBoxDataSO();
    }

    protected override void FixedValue()
    {
        _projectileRotate = _ninjaStarBoxDataSO.ProjectileRotate;
        _speed = _ninjaStarBoxDataSO.NinjaStarSpeed;
        _duration = _ninjaStarBoxDataSO.NinjaStarDuration;
    }

    public override void UseWeapon()
    {
        if (gameObject.activeSelf)
        {
            LevelUp();
        }
        gameObject.SetActive(true);
    }

    void OnEnable()
    {
        FixedValue();
        LevelValue(_weaponLevel);
        _throwingNinjaStarCoHandle = StartCoroutine(ThrowingNinjaStarCo());
    }

    void OnDisable()
    {
        StopCoHandle(_throwingNinjaStarCoHandle);
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
        _damage = _ninjaStarBoxDataSO.NinjaStarDamages[level];
        _coolTime = _ninjaStarBoxDataSO.NinjaStarCoolTimes[level];
    }
    
    Coroutine _throwingNinjaStarCoHandle;
    IEnumerator ThrowingNinjaStarCo()
    {
        while (true)
        {
            if (Player.Instance.IsAtropine)
            {
                yield return _ninjaStarBoxDataSO.AtropineNinjaStarCoolTime;
                ThrowingNinjaStar(_ninjaStarBoxDataSO.AtroPineNinjaStarDamage);
            }
            else
            {
                yield return _coolTime;
                ThrowingNinjaStar(_damage);
            }
        }
    }

    void ThrowingNinjaStar(float ninjaStarDamage)
    {
        NinjaStar ninjaStar = FactoryManager.Instance.GetNinjaStar();
        ninjaStar.Initiazlie(ninjaStarDamage, _speed, _duration, _projectileRotate);
        ninjaStar.AttackPoint(transform.position);
        ninjaStar.Throw(_attackDirection);
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }

}
