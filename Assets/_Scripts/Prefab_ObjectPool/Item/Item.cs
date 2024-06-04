using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : RecycleObject
{
    float _duration = 0.5f;
    bool _isGet;


    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        _isGet = false;
        OnStart();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        GetItem();
    }

    float Move()
    {
        float result;
        result = transform.position.y + 1.5f;
        return result;
    }

    void GetItem()
    {
        if (_isGet)
        {
            return;
        }
        _isGet = true;
        ItemFunction();
        var sequence = DOTween.Sequence().OnComplete(Restore);
        sequence.Append(transform.DOMoveY(Move(), _duration));
        sequence.Join(transform.DOScale(Vector3.zero, _duration));
    }

    protected virtual void ItemFunction()
    {

    }

    protected virtual void OnStart()
    {

    }

  
}
