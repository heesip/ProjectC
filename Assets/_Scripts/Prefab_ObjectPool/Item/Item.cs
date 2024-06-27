using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : RecycleObject
{
    bool _isGet;
    float _duration = 0.3f;

    protected virtual void ItemFunction() { }
    protected virtual void OnStart() { }

    void OnEnable()
    {
        transform.localScale = Vector3.one;
        _isGet = false;
        OnStart();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Player))
        {
            return;
        }
        GetItem();
    }

    public void GetItem()
    {
        if (_isGet)
        {
            return;
        }

        _isGet = true;

        ItemFunction();
        var playerPosition = Player.Instance.transform.position;
        var sequence = DOTween.Sequence();

        Vector3 direction = (transform.position - playerPosition).normalized;
        Vector3 target = gameObject.transform.position + direction;
        sequence.Append(transform.DOMove(target, _duration));
        sequence.Append(transform.DOMove(playerPosition, _duration));
        sequence.Join(transform.DOScale(Vector3.zero, _duration)).OnComplete(Restore);
    }

}
