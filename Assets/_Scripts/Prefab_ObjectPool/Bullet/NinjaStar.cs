using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NinjaStar : Bullet
{
    [SerializeField] Sprite[] _sprites;
    bool _isAttack;
    bool _isRare;
    float _speed;
    float _rotateDuration;
    Vector3 _rotateVector;

    public void Initiazlie(float damage, float speed, float rotateDuration, Vector3 rotateVector)
    {
        _damage = damage;
        _speed = speed;
        _rotateDuration = rotateDuration;
        _rotateVector = rotateVector;
    }

    protected override void OnStart()
    {
        transform.DOKill();
        _isRare = AchieveManager.Instance.IsRareNinjaStar;
        switch (_isRare)
        {
            case true:
                _spriteRenderer.sprite = _sprites[1];
                break;
            case false:
                _spriteRenderer.sprite = _sprites[0];
                break;
        }
    }

    void OnDisable()
    {
        StopCoHandle(_throwingCoHandle);
        _isAttack = false;
    }

    void NinjaStarRotate()
    {
        transform.DORotate(_rotateVector, _rotateDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }

    Coroutine _throwingCoHandle;

    IEnumerator ThrowingCo(Vector3 nextVector)
    {
        if (_isAttack)
        {
            yield break;
        }
        _isAttack = true;
        while (_isAttack)
        {
            transform.position += _speed * Time.deltaTime * nextVector;
            yield return null;
        }

    }

    public void Throw(Vector3 nextVector)
    {
        if (_isAttack)
        {
            return;
        }
        NinjaStarRotate();
        _throwingCoHandle = StartCoroutine(ThrowingCo(nextVector));
    }
}
