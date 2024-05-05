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
    [SerializeField] Vector3 _fjorginRightPos = new Vector3(0, 2.5f, 0);
    [SerializeField] Vector3 _fjorginLeftPos = new Vector3(0, 2.5f, 0);

    WaitForSeconds _coolTime = new WaitForSeconds(3);



    protected override void Initialize()
    {
        _collider = _fjorgin.GetComponent<Collider2D>();
        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _fjorgin.transform.Translate(transform.up);
        _rightPos = _fjorginRightPos;
        _leftPos = _fjorginLeftPos;
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
            yield return null;
            AttackPosition();
            Vector3 rotVec = Player.Instance.IsLeft ? Vector3.forward : Vector3.back;
            transform.DORotate(rotVec * 90, 1).SetEase(Ease.InQuint);
            yield return _coolTime;
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
        _isReverse = Player.Instance.IsLeft;
        _fjorginSprite.flipX = !_isReverse;
        transform.localPosition = _isReverse ? _leftPos : _rightPos;
        _collider.enabled = true;
        _fjorginSprite.enabled = true;
        transform.SetParent(null);
    }

    void WeaponReturn()
    {
        _collider.enabled = false;
        _fjorginSprite.enabled = false;
        transform.DORotate(Vector3.zero, 0);
        transform.SetParent(Player.Instance.transform);
    }


}
