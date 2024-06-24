using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fjorgin : Weapon
{
    [SerializeField] GameObject _fjorgin;
    SpriteRenderer _fjorginSprite;
    Collider2D _collider;

    [SerializeField] FjorginDataSO _fjorginDataSO;
    Vector3 _readyPosition;
    Vector3 _rotateDirection;
    Vector3 _rotateVector;
    Quaternion _readyRotation;
    float _rotate360Duration;
    float _rotate90Duration;
    WaitForSeconds _oneSecond;

    protected override void Initialize()
    {
        _fjorginDataSO = GameDataManager.Instance.GetFjorginDataSO();
        _collider = _fjorgin.GetComponent<Collider2D>();
        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _fjorgin.transform.Translate(transform.up);
    }


    protected override void FixedValue()
    {
        _readyPosition = _fjorginDataSO.FjorginPosition;
        _rotateDirection = _fjorginDataSO.FjorginRotateDirection;
        _rotateVector = _fjorginDataSO.FjorginAttack;
        _readyRotation = _fjorginDataSO.FjorginRotation;
        _rotate360Duration = _fjorginDataSO.Fjorgin360RotateDuration;
        _rotate90Duration = _fjorginDataSO.Fjorgin90RotateDuration;
        _coolTime = _fjorginDataSO.FjorginCoolTime;
        _oneSecond = _fjorginDataSO.OneSecond;
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
            WeaponReturn();
            yield return _coolTime;
            AttackPosition();
            yield return _oneSecond;
            FjorginBuff fjorginBuff = FactoryManager.Instance.GetFjorginBuff();
            fjorginBuff.transform.position = transform.position + _fjorginDataSO.FjorginBuffPosition;
            fjorginBuff.MagicSquare(_rotate360Duration);
            Tween rotate360 = transform.DORotate(_rotateDirection, _rotate360Duration, RotateMode.FastBeyond360);
            yield return rotate360.WaitForCompletion();
            Tween tween2 = transform.DORotate(_rotateVector, _rotate90Duration).SetEase(Ease.InQuint);
            yield return tween2.WaitForCompletion();
            fjorginBuff.ShockWave();
            yield return _oneSecond;

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
        transform.localPosition = _readyPosition;
        _collider.enabled = true;
        _fjorginSprite.enabled = true;
        transform.SetParent(null);
    }

    void WeaponReturn()
    {
        _fjorginSprite.enabled = false;
        _collider.enabled = false;
        transform.rotation = _readyRotation;
        transform.SetParent(Player.Instance.transform);
    }

}
