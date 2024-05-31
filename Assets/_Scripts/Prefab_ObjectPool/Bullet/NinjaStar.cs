using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NinjaStar : Bullet
{
    [SerializeField] Sprite[] _sprites;
    bool _isAttack;

    //TempCode
    [SerializeField] bool _isRare;

    protected override void OnStart()
    {
        transform.DOKill();
        switch (_isRare)
        {
            case false:
                _spriteRenderer.sprite = _sprites[0];
                break;
            case true:
                _spriteRenderer.sprite = _sprites[1];
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
            transform.position += speed * Time.deltaTime * nextVector;
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
