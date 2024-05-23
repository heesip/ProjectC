using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NinjaStar : Projectile
{
    [SerializeField] Sprite[] _sprites;

    [SerializeField] bool _isRare;

    new void OnEnable()
    {
        // base.OnEnable();
        switch (_isRare)
        {
            case false:
                _sprite.sprite = _sprites[0];
                break;
            case true:
                _sprite.sprite = _sprites[1];
                break;
        }

        _rotateCo = StartCoroutine(RotateCo());

    }

    void OnDisable()
    {
        StopRotateCo();
    }

    Coroutine _rotateCo;

    IEnumerator RotateCo()
    {
        Tween tween;
        while (true)
        {
            tween = transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetEase(Ease.Linear);
            yield return tween.WaitForCompletion();
            tween.Kill();
        }
    }

    void StopRotateCo()
    {
        if (_rotateCo != null)
        {
            StopCoroutine(_rotateCo);
        }
    }
    public void Throw(Vector2 nextVector, float duration)
    {
        // transform.DOMove(nextVector, duration);
    }


}
