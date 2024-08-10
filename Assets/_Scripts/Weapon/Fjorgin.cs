using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fjorgin : Singleton<Fjorgin>
{
    [SerializeField] GameObject _fjorgin;
    SpriteRenderer _fjorginSprite;
    Collider2D _collider;

    [SerializeField] WeaponDataSO _weaponDataSO;
    Vector3 _readyPosition;
    Vector3 _rotateDirection;
    Vector3 _rotateVector;
    Quaternion _readyRotation;
    float _rotate360Duration;
    float _rotate90Duration;

    readonly int _maxLevel = 3;
    int _level;
    public int Level => _level;

    WaitForSeconds _oneSecond;
    WaitForSeconds _coolTime;
    void Awake()
    {
        _collider = _fjorgin.GetComponent<Collider2D>();
        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _fjorgin.transform.Translate(transform.up);
        DataLoad();
    }
    void DataLoad()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
        _readyPosition = _weaponDataSO.FjorginPosition;
        _rotateDirection = _weaponDataSO.FjorginRotateDirection;
        _rotateVector = _weaponDataSO.FjorginAttack;
        _readyRotation = _weaponDataSO.FjorginRotation;
        _rotate360Duration = _weaponDataSO.Fjorgin360RotateDuration;
        _rotate90Duration = _weaponDataSO.Fjorgin90RotateDuration;
        _coolTime = _weaponDataSO.FjorginCoolTime;
        _oneSecond = _weaponDataSO.OneSecond;
    }

    public void UseWeapon()
    {
        LevelUp();
        gameObject.SetActive(true);
    }

    void LevelUp()
    {
        if (_level > 0)
        {
            WeaponReturn();
            gameObject.SetActive(false);
        }
        if (_level < _maxLevel)
        {
            _level++;
        }
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
            fjorginBuff.transform.position = transform.position + _weaponDataSO.FjorginBuffPosition;
            fjorginBuff.MagicSquare(_rotate360Duration);
            Tween rotate360 = transform.DORotate(_rotateDirection, _rotate360Duration, RotateMode.FastBeyond360);
            yield return rotate360.WaitForCompletion();
            Tween attack = transform.DORotate(_rotateVector, _rotate90Duration).SetEase(Ease.InQuint);
            yield return attack.WaitForCompletion();
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
