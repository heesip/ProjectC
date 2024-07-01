using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dron : Weapon
{
    [SerializeField] Transform _dronAttackPoint1;
    [SerializeField] Transform _dronAttackPoint2;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] DronDataSO _dronDataSO;

    Vector3 _rightPosition;
    Vector3 _leftPosition;
    int _range;

    protected override void Initialize()
    {
        _dronDataSO = GameDataManager.Instance.GetDronDataSO();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void FixedValue()
    {
        _rightPosition = _dronDataSO.DronRightPosition;
        _leftPosition = _dronDataSO.DronLeftPosition;
        _count = _dronDataSO.DronCount;
        _speed = _dronDataSO.DronSpeed;
        _range = _dronDataSO.DronRange;
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
        _coolTime = _dronDataSO.DronCoolTimes[level];
        _damage = _dronDataSO.DronDamages[level];
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
                missile.Shoting(NextVector().x, _speed, CheckAtropine().damage);
            }
        }
    }

    (WaitForSeconds coolTime, float damage) CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return (_dronDataSO.AtropineDronCoolTimes[_weaponLevel],
                _dronDataSO.AtroPineDronDamages[_weaponLevel]);
        }
        else
        {
            return (_coolTime, _damage);
        }
    }

    Vector2 NextVector()
    {
        return transform.position + (Player.Instance.IsLeft ? Vector3.left : Vector3.right) * _range;
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }

    void OnDisable()
    {
        StopAttackCo();
    }
}
