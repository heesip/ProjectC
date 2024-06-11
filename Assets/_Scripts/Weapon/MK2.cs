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

    void LevelValue(int level)
    {
        _damage = _mk2DataSO.Mk2Damages[level];
        _coolTime = _mk2DataSO.Mk2CoolTimes[level];
        _count = _mk2DataSO.Mk2Counts[level];
    }

    void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
        LevelValue(0);
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
        Tween tween;
        while (true)
        {
            yield return _coolTime;
            AttackPosition();
            tween = transform.DORotate(EndValue(), _speed, RotateMode.FastBeyond360).SetEase(Ease.InSine);
            yield return tween.WaitForCompletion();
            WeaponReturn();
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
