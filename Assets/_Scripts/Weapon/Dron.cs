using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dron : Weapon
{
    [SerializeField] Transform _dronAttackPoint1;
    [SerializeField] Transform _dronAttackPoint2;
    WaitForSeconds _coolTime = new WaitForSeconds(3);
    [SerializeField] SpriteRenderer _sprite;

    //Temp Code
    [SerializeField] Vector3 _dronRightPos = new Vector3(-1, 1.5f, 0);
    [SerializeField] Vector3 _dronLeftPos = new Vector3(1, 1.5f, 0);
    [SerializeField] int _count = 2;
    [SerializeField] int _range = 22;
    private void Awake()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _rightPos = _dronRightPos;
        _leftPos = _dronLeftPos;
        _speed = 1.2f;
    }

    private void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;
        _sprite.flipX = isReverse;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
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
            Projectile[] missile = new Projectile[_count];

            for (int i = 0; i < missile.Length; i++)
            {
                missile[i] = FactoryManager.Instance.GetMissile();
               // missile[i].GetComponent<SpriteRenderer>().flipX = Player.Instance.IsLeft ? true : false;

                switch (i % 2)
                {
                    case 0:
                        missile[i].AttackPoint(_dronAttackPoint1.position);
                        missile[i].Shot(NextVector().x, _speed);
                        break;
                    case 1:
                        missile[i].AttackPoint(_dronAttackPoint2.position);
                        missile[i].Shot(NextVector().x, _speed);
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
