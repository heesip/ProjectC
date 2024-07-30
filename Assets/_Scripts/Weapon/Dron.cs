using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dron : Singleton<Dron>
{
    [SerializeField] Transform _dronAttackPoint1;
    [SerializeField] Transform _dronAttackPoint2;
    SpriteRenderer _spriteRenderer;
    WeaponDataSO _weaponDataSO;
    Vector3 _rightPosition;
    Vector3 _leftPosition;

    readonly int _maxLevel = 2;
    int _weaponLevel;

    int _count;
    int _range;
    float _damage;
    float _speed;
    WaitForSeconds _coolTime;
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
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _rightPosition = _weaponDataSO.DronRightPosition;
        _leftPosition = _weaponDataSO.DronLeftPosition;
        _count = _weaponDataSO.DronCount;
        _speed = _weaponDataSO.DronSpeed;
        _range = _weaponDataSO.DronRange;
    }

    void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;
        _spriteRenderer.flipX = isReverse;
        transform.localPosition = isReverse ? _leftPosition : _rightPosition;
    }

    void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
        LevelValue(_weaponLevel);
    }

    void OnDisable()
    {
        StopAttackCo();
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
        _coolTime = _weaponDataSO.DronCoolTimes[level];
        _damage = _weaponDataSO.DronDamages[level];
    }

    Coroutine _attackCoHandle;
    IEnumerator AttackCo()
    {
        while (true)
        {
            yield return CheckAtropine().coolTime;

            for (int i = 0; i < _count; i++)
            {
                Vector3 attackPoint = i % 2 == 0 ? _dronAttackPoint1.position : _dronAttackPoint2.position;
                Missile missile = FactoryManager.Instance.GetMissile();
                missile.AttackPoint(attackPoint);
                missile.Shoting(_targetVecter.x, _speed, CheckAtropine().damage);
            }
        }
    }
    Vector2 _targetVecter => transform.position + (Player.Instance.IsLeft ? Vector3.left : Vector3.right) * _range;

    (WaitForSeconds coolTime, float damage) CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return (_weaponDataSO.AtropineDronCoolTimes[_weaponLevel],
                _weaponDataSO.AtroPineDronDamages[_weaponLevel]);
        }
        else
        {
            return (_coolTime, _damage);
        }
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }
}
