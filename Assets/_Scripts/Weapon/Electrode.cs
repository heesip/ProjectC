using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrode : Weapon
{
    [SerializeField] ElectrodeDataSO _electrodeDataSO;
    Collider2D _collider;
    SpriteRenderer _spriteRenderer;

    float _electrodeSize;
    WaitForSeconds _attackInterval;


    protected override void Initialize()
    {
        _electrodeDataSO = GameDataManager.Instance.GetElectrodeDataSO();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void FixedValue()
    {
        _count = _electrodeDataSO.ElectrodeCount;
        _attackInterval = _electrodeDataSO.AttackInterval;
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
        _collider.enabled = false;
        gameObject.SetActive(false);
        if (_weaponLevel < _maxLevel)
        {
            _weaponLevel++;
        }
    }

    void LevelValue(int level)
    {
        _coolTime = _electrodeDataSO.ElectrodeCoolTimes[level];
        _damage = _electrodeDataSO.ElectrodeDamages[level];
        _electrodeSize = _electrodeDataSO.ElectrodeSizes[level];

    }

    void OnEnable()
    {
        LevelValue(_weaponLevel);
        transform.localScale = Vector3.one * _electrodeSize;
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void OnDisable()
    {
        StopAttackCo();
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            _spriteRenderer.enabled = true;
            for (int i = 0; i < _count; i++)
            {
                _collider.enabled = !_collider.enabled;
                yield return _attackInterval;
            }
            _spriteRenderer.enabled = false;
            yield return _coolTime;
        }
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
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
