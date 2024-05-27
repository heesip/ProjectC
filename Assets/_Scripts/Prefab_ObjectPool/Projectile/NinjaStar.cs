using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NinjaStar : Projectile
{
    [SerializeField] Sprite[] _sprites;
    [SerializeField] bool _isRare;
    bool _isAttack;

    new void OnEnable()
    {
        base.OnEnable();
        transform.DOKill();
        switch (_isRare)
        {
            case false:
                _sprite.sprite = _sprites[0];
                break;
            case true:
                _sprite.sprite = _sprites[1];
                break;
        }
        NinjaStarRotate();

    }

    void OnDisable()
    {
        StopCoHandle(_throwingCoHandle);
        _isAttack = false;
    }

    void NinjaStarRotate()
    {
        transform.DORotate(new Vector3(0, 0, -360 * 5), 1.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }

    Coroutine _throwingCoHandle;

    IEnumerator ThrowingCo(Vector3 nextVector, float speed)
    {
        if (_isAttack)
        {
            yield break;
        }
        _isAttack = true;
        while (_isAttack)
        {
            transform.position += nextVector * speed * Time.deltaTime;
            yield return null;
        }

    }

    public void Throw(Vector3 nextVector, float speed)
    {
        if (_isAttack)
        {
            return;
        }
        _throwingCoHandle = StartCoroutine(ThrowingCo(nextVector, speed));
    }
}
