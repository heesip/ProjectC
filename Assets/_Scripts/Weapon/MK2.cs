using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using Unity.VisualScripting;

public class Mk2 : Singleton<Mk2>
{
    [SerializeField] GameObject _mk2;
    SpriteRenderer _mk2SpriteRenderer;
    Collider2D _collider;
    WeaponDataSO _weaponDataSO;

    Vector3 _rightPosition;
    Vector3 _leftPosition;
    Vector3 _rotateDirection;

    readonly int _maxLevel = 2;
    int _level;
    public int Level => _level;

    int _count;
    float _damage;
    float _speed;
    WaitForSeconds _coolTime;

    void Awake()
    {
        _mk2SpriteRenderer = _mk2.GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _mk2.transform.Translate(transform.up, Space.World);
        DataLoad();
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

    void DataLoad()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _mk2.transform.rotation = _weaponDataSO.Mk2Rotation;
        _rightPosition = _weaponDataSO.Mk2RightPosition;
        _leftPosition = _weaponDataSO.Mk2LeftPosition;
        _rotateDirection = _weaponDataSO.Mk2RotateDirection;
        _speed = _weaponDataSO.Mk2Speed;
    }

    public void UseWeapon()
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
        if (_level < _maxLevel)
        {
            _level++;
        }
    }

    void LevelValue(int level)
    {
        _coolTime = _weaponDataSO.Mk2CoolTimes[level];
        _count = _weaponDataSO.Mk2Counts[level];
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
            _damage = CheckAtropine().damage;
            AttackPosition();
            Tween attack = transform.DORotate(EndValue(), _speed, RotateMode.FastBeyond360).SetEase(Ease.InSine);
            yield return attack.WaitForCompletion();
            WeaponReturn();
            yield return CheckAtropine().coolTime;
        }
    }

    (WaitForSeconds coolTime, float damage) CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return (_weaponDataSO.AtropineMk2CoolTimes[_level], _weaponDataSO.AtropineMk2Damage);
        }
        else
        {
            return (_coolTime, _weaponDataSO.Mk2Damage);
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
}
