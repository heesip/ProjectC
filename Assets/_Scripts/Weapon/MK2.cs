using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class MK2 : Weapon
{
    [SerializeField] GameObject _mk2;
    [SerializeField] SpriteRenderer _mk2Sprite;
    [SerializeField] Collider2D _collider;
    //Temp Code
    [SerializeField] Vector3 _mk2RightPos = new Vector3(-2f, 0, 0);
    [SerializeField] Vector3 _mk2LeftPos = new Vector3(2f, 0, 0);
    [SerializeField] Quaternion _mk2Rot = Quaternion.Euler(0, 0, -90);

    WaitForSeconds _coolTime = new WaitForSeconds(3);
    protected override void Initialize()
    {
        _mk2Sprite = _mk2.GetComponent<SpriteRenderer>();
        _collider = _mk2.GetComponent<Collider2D>();
        _mk2.transform.rotation = _mk2Rot;

        _rightPos = _mk2RightPos;
        _leftPos = _mk2LeftPos;
        _mk2.transform.Translate(transform.up, Space.World);
        _speed = 1.5f;

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
        _mk2Sprite.enabled = true;
        _collider.enabled = true;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
        transform.SetParent(null);
    }

    void WeaponReturn()
    {
        transform.DOKill();
        _collider.enabled = false;
        _mk2Sprite.enabled = false;
        //transform.DORotate(Vector3.zero, 0);
        transform.SetParent(Player.Instance.transform);
    }
}
