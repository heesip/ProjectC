using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Projectile : RecycleObject
{
    SpriteRenderer _sprite;
    [SerializeField] int _id;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        switch (_id)
        {
            case 0:
                _sprite.flipX = Player.Instance.IsLeft;
                break;
            default:
                _rotateCo = StartCoroutine(RotateCo());
                break;
        }
    }

    private void OnDisable()
    {
        StopRotateCo();
    }

    public void AttackPoint(Vector2 attackPoint)
    {
        transform.position = attackPoint;
    }
    public void Shot(float nextVector_X, float duration)
    {
        transform.DOMoveX(nextVector_X, duration).SetEase(Ease.InCubic);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        Remove();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Remove();
    }
    private void Remove()
    {
        transform.DOKill();
        Restore();
    }

    Coroutine _rotateCo;

    IEnumerator RotateCo()
    {
        Tween tween;
        while (true)
        {
            tween = transform.DORotate(new Vector3(0, 0, -360 * 3), 3, RotateMode.FastBeyond360).SetEase(Ease.Linear);
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


}
