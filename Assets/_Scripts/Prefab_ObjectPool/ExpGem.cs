using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpGem : RecycleObject
{
    [SerializeField] bool _isFly;
    //Temp Code
    [SerializeField] float _gemMoveUp = 1.5f;
    [SerializeField] float _gemMoveDuration = 0.5f;

    private void OnEnable()
    {
        _isFly = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        FlyExpGem();
    }


    void FlyExpGem()
    {

        if (_isFly)
        {
            return;
        }

        _isFly = true;

        var originalPosition = transform.position;
        var sequence = DOTween.Sequence().OnComplete(Restore);
        sequence.Append(transform.DOMoveY(originalPosition.y + _gemMoveUp, _gemMoveDuration));
    }


}
