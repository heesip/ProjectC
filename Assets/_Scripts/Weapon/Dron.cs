using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dron : Weapon
{
    [SerializeField] Transform _dronAttackPoint1;
    [SerializeField] Transform _dronAttackPoint2;
    [SerializeField] SpriteRenderer _spriteRenderer;

    //Temp Code
    [SerializeField] Vector3 _dronRightPosition = new Vector3(-1, 1.5f, 0);
    [SerializeField] Vector3 _dronLeftPosition = new Vector3(1, 1.5f, 0);
    [SerializeField] int _range = 22;
    private void Awake()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rightPosition = _dronRightPosition;
        _leftPosition = _dronLeftPosition;
        _coolTime = new WaitForSeconds(3);
        _count = 2;
        _speed = 1.2f;
    }

    private void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;
        _spriteRenderer.flipX = isReverse;
        transform.localPosition = isReverse ? _leftPosition : _rightPosition;
    }
    private void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
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
                        missiles[i].Shoting(NextVector().x, _speed);
                        break;
                    case 1:
                        missiles[i].AttackPoint(_dronAttackPoint2.position);
                        missiles[i].Shoting(NextVector().x, _speed);
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
