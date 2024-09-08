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

    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    readonly int _number = 2;
    int _count;
    int _range;
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
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        DataLoad();
        Positioning();
    }

    void LateUpdate()
    {
        Positioning();
    }

    void OnEnable()
    {
        LevelValue(_level);
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
        _count = _weaponDataSO.DronCount;
        _speed = _weaponDataSO.DronSpeed;
        _range = _weaponDataSO.DronRange;
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
            for (int number = 0; number < _number; number++)
            {
                for (int count = 0; count < _count; count++)
                {
                    Vector3 attackPoint = count % 2 == 0 ? _dronAttackPoint1.position : _dronAttackPoint2.position;
                    Missile missile = FactoryManager.Instance.GetMissile();
                    missile.AttackPoint(attackPoint);
                    missile.Shoting(_targetVecter.x, _speed, CheckAtropine().damage);
                }
                AudioManager.Instance.PlaySFX(SFXType.Range);
                yield return new WaitForSeconds(.3f);
            }
            yield return CheckAtropine().coolTime;
        }
    }
    Vector2 _targetVecter => transform.position + (Player.Instance.IsLeft ? Vector3.left : Vector3.right) * _range;

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
