using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrode : Singleton<Electrode>
{
    WeaponDataSO _weaponDataSO;
    Collider2D _collider;

    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    float _damage;
    float _damageAtropine;
    float _electrodeSize;
    WaitForSeconds _attackDelay;

    public void UseWeapon()
    {
        LevelUp();
        gameObject.SetActive(true);
    }

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _attackDelay = _weaponDataSO.AttackDelay;
        _damageAtropine = _weaponDataSO.AtropineElectrodeDamage;
    }

    void OnEnable()
    {
        LevelValue(_level);
        transform.localScale = Vector3.one * _electrodeSize;
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

    void LevelUp()
    {
        if (Level > 0)
        {
            _collider.enabled = false;
        }
        gameObject.SetActive(false);
        if (_level < _maxLevel)
        {
            _level++;
        }
    }

    void LevelValue(int level)
    {
        _electrodeSize = _weaponDataSO.ElectrodeSizes[level];
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            _damage = CheckAtropine();
            _collider.enabled = !_collider.enabled;
            if (_collider.enabled)
            {
                AudioManager.Instance.PlaySFX(SFXType.Electrode);
            }
            yield return _attackDelay;
        }
    }

    float CheckAtropine()
    {
        if (Player.Instance.IsAtropine)
        {
            return _damageAtropine;

        }
        else
        {
            return _weaponDataSO.ElectrodeDamage;
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
