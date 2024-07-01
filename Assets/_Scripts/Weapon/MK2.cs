using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class Mk2 : Weapon
{
    [SerializeField] GameObject _mk2;
    [SerializeField] SpriteRenderer _mk2SpriteRenderer;
    [SerializeField] Collider2D _collider;
    [SerializeField] Mk2DataSO _mk2DataSO;

    Vector3 _rightPosition;
    Vector3 _leftPosition;
    Vector3 _rotateDirection;

    protected override void Initialize()
    {
        _mk2DataSO = GameDataManager.Instance.GetMk2DataSO();
        _mk2SpriteRenderer = _mk2.GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _mk2.transform.Translate(transform.up, Space.World);
    }

    protected override void FixedValue()
    {
        _mk2.transform.rotation = _mk2DataSO.Mk2Rotation;
        _rightPosition = _mk2DataSO.Mk2RightPosition;
        _leftPosition = _mk2DataSO.Mk2LeftPosition;
        _rotateDirection = _mk2DataSO.Mk2RotateDirection;
        _speed = _mk2DataSO.Mk2Speed;
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
        WeaponReturn();
        gameObject.SetActive(false);
        if (_weaponLevel < _maxLevel)
        {
            _weaponLevel++;
        }
    }

    void LevelValue(int level)
    {
        _coolTime = _mk2DataSO.Mk2CoolTimes[level];
        _count = _mk2DataSO.Mk2Counts[level];
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

    Vector3 EndValue()
    {
        return _rotateDirection * _count;
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            yield return CheckAtropine().coolTime;
            _damage = CheckAtropine().damage;
            AttackPosition();
            Tween attack = transform.DORotate(EndValue(), _speed, RotateMode.FastBeyond360).SetEase(Ease.InSine);
            yield return attack.WaitForCompletion();
            WeaponReturn();
        }
    }

    (WaitForSeconds coolTime, float damage) CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return (_mk2DataSO.AtropineMk2CoolTimes[_weaponLevel], _mk2DataSO.AtropineMk2Damage);
        }
        else
        {
            return (_coolTime, _mk2DataSO.Mk2Damage);
        }
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }

    void AttackPosition()
    {
        bool isReverse = Player.Instance.IsLeft;
        _mk2SpriteRenderer.enabled = true;
        _collider.enabled = true;
        transform.localPosition = isReverse ? _leftPosition : _rightPosition;
        transform.SetParent(null);
    }

    void WeaponReturn()
    {
        transform.DOKill();
        _collider.enabled = false;
        _mk2SpriteRenderer.enabled = false;
        transform.SetParent(Player.Instance.transform);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Enemy))
        {
            return;
        }
        var enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.OnDamage(gameObject, _damage);
        }
    }
}
