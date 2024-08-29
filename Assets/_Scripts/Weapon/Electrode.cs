using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrode : Singleton<Electrode>
{
    WeaponDataSO _weaponDataSO;
    Collider2D _collider;
    SpriteRenderer _spriteRenderer;

    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    int _count;
    float _damage;
    float _damageAtropine;
    float _electrodeSize;
    WaitForSeconds _coolTime;
    WaitForSeconds _coolTimeAtropine;
    WaitForSeconds _attackDelay;

    public void UseWeapon()
    {
        LevelUp();
        gameObject.SetActive(true);
    }

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _count = _weaponDataSO.ElectrodeCount;
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
        _coolTime = new WaitForSeconds(_weaponDataSO.ElectrodeCoolTimes[level]);
        _coolTimeAtropine = new(_weaponDataSO.AtropineElectrodeCoolTimes[level]);
        _electrodeSize = _weaponDataSO.ElectrodeSizes[level];
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            _damage = CheckAtropine().damage;
            _spriteRenderer.enabled = true;
            for (int i = 0; i < _count; i++)
            {
                _collider.enabled = !_collider.enabled;
                if (_collider.enabled)
                {
                    AudioManager.Instance.PlaySFX(SFXType.Electrode);
                }
                yield return _attackDelay;
            }
            _spriteRenderer.enabled = false;

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
            return (_coolTime, _weaponDataSO.ElectrodeDamage);
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
