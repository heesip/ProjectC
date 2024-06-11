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
        LevelValue(0);
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            yield return _coolTime;
            Missile[] missiles = new Missile[_count];

            for (int i = 0; i < missiles.Length; i++)
            {
                missiles[i] = FactoryManager.Instance.GetMissile();
                switch (i % 2)
                {
                    case 0:
                        missiles[i].AttackPoint(_dronAttackPoint1.position);
                        missiles[i].Shoting(NextVector().x, _speed, _damage);
                        break;
                    case 1:
                        missiles[i].AttackPoint(_dronAttackPoint2.position);
                        missiles[i].Shoting(NextVector().x, _speed, _damage);
                        break;
                    default:
                        break;
                }
            }

        }
    }

    Vector2 NextVector()
    {
        Vector2 nextVector;
        Vector2 curVector = transform.position;
        Vector2 direction = Player.Instance.IsLeft ? Vector2.left : Vector2.right;
        nextVector = curVector + (direction * _range);
        return nextVector;
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
