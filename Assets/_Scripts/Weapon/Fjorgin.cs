using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fjorgin : Weapon
{
    [SerializeField] GameObject _fjorgin;
    SpriteRenderer _fjorginSprite;
    Collider2D _collider;
    [SerializeField] bool _isReverse;
    //Temp Code
    [SerializeField] Vector3 _fjorginPosition = new Vector3(1, 2.5f, 0);
    [SerializeField] Quaternion _fjorginRotation = Quaternion.Euler(0, 0, 45);
    WaitForSeconds _oneSecond = new WaitForSeconds(1);



    protected override void Initialize()
    {
        _collider = _fjorgin.GetComponent<Collider2D>();
        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _fjorgin.transform.Translate(transform.up);
        transform.rotation = _fjorginRotation;
        _rightPosition = _fjorginPosition;

        _coolTime = new WaitForSeconds(3);
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
        while (true)
        {
            AttackPosition();
            yield return _oneSecond;
            Tween rotate360 = transform.DORotate(new Vector3(0, 0, -315), .7f, RotateMode.FastBeyond360);
            yield return rotate360.WaitForCompletion();
            transform.DORotate(Vector3.back * 90, .5f).SetEase(Ease.InQuint);
            yield return new WaitForSeconds(1f);
            _fjorginSprite.enabled = false;
            yield return _oneSecond;
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
        transform.localPosition = _rightPosition;
        _collider.enabled = true;
        _fjorginSprite.enabled = true;
        transform.SetParent(null);
    }

    void WeaponReturn()
    {
        _collider.enabled = false;
        transform.rotation = _fjorginRotation;
        transform.SetParent(Player.Instance.transform);
    }


}
