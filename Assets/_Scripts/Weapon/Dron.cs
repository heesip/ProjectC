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
    Laser _laser;
    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    float _damage;
    float _damageAtropine;
    WaitForSeconds _coolTime;
    WaitForSeconds _coolTimeAtropine;
    public void UseWeapon()
    {
        LevelUp();
        gameObject.SetActive(true);
    }
    void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _laser = GetComponentInChildren<Laser>();
        DataLoad();
        Positioning();
    }

    void LateUpdate()
    {
        Positioning();
        _laser.Positioning(transform.position);
    }

    void OnEnable()
    {
        LevelValue(_level);
        _laser.Initialize();
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void OnDisable()
    {
        StopAttackCo();
    }

    void DataLoad()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _rightPosition = _weaponDataSO.DronRightPosition;
        _leftPosition = _weaponDataSO.DronLeftPosition;
    }

    void Positioning()
    {
        bool isReverse = Player.Instance.IsLeft;
        _spriteRenderer.flipX = isReverse;
        transform.localPosition = isReverse ? _leftPosition : _rightPosition;
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
        _coolTime = new WaitForSeconds(_weaponDataSO.DronCoolTimes[level]);
        _damage = _weaponDataSO.DronDamages[level];
        _coolTimeAtropine = new WaitForSeconds(_weaponDataSO.AtropineDronCoolTimes[_level]);
        _damageAtropine = _weaponDataSO.AtroPineDronDamages[_level];
    }

    Coroutine _attackCoHandle;
    IEnumerator AttackCo()
    {
        while (true)
        {
            _laser.Attack(CheckAtropine().damage);
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

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }
}
