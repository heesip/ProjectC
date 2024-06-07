using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class MK2 : Weapon
{
    [SerializeField] GameObject _mk2;
    [SerializeField] SpriteRenderer _mk2SpriteRenderer;
    [SerializeField] Collider2D _collider;
    //Temp Code
    [SerializeField] Vector3 _mk2RightPosition = new Vector3(-2f, 0, 0);
    [SerializeField] Vector3 _mk2LeftPosition = new Vector3(2f, 0, 0);
    [SerializeField] Quaternion _mk2Rotation = Quaternion.Euler(0, 0, -90);

    WaitForSeconds _coolTime = new WaitForSeconds(3);
    protected override void Initialize()
    {
        _mk2SpriteRenderer = _mk2.GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _mk2.transform.rotation = _mk2Rotation;

        _rightPosition = _mk2RightPosition;
        _leftPosition = _mk2LeftPosition;
        _mk2.transform.Translate(transform.up, Space.World);
        _speed = 1.5f;
        _damage = 2;
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }
    private void OnDisable()
    {
        StopAttackCo();
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        Tween tween;
        while (true)
        {
            AttackPosition();
            tween = transform.DORotate(new Vector3(0, 0, -360 * 3), 1.5f, RotateMode.FastBeyond360).SetEase(Ease.InSine);
            yield return tween.WaitForCompletion();
            WeaponReturn();
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

    private void OnTriggerEnter2D(Collider2D collision)
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
