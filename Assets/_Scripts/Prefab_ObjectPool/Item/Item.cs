using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : RecycleObject
{
    protected bool _isGet;
    protected float _duration = 0.3f; 
    [SerializeField] protected GameObject _light;


    protected virtual void ItemFunction() { }
    protected virtual void OnStart() { }

    protected virtual void GetItem()
    {
        if (_isGet)
        {
            return;
        }

        _isGet = true;
        _light.SetActive(!_isGet);

        ItemFunction();
        var sequence = DOTween.Sequence();

        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 direction = (transform.position - playerPosition).normalized;
        Vector3 target = gameObject.transform.position + direction;
        sequence.Append(transform.DOMove(target, _duration));
        sequence.Append(transform.DOMove(playerPosition, _duration));
        sequence.Join(transform.DOScale(Vector3.zero, _duration)).OnComplete(Restore);
    }

    void OnEnable()
    {
        transform.localScale = Vector3.one;
        _isGet = false;
        _light.SetActive(!_isGet);
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

}
