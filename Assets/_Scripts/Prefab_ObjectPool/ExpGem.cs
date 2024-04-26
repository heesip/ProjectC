using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpGem : RecycleObject
{
    [SerializeField] bool isFly;
    //Temp Code
    [SerializeField] float _gemMoveUp = 1.5f;
    [SerializeField] float _gemMoveDuration = 0.5f;

    private void OnEnable()
    {
        isFly = false;
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

        if (isFly)
        {
            return;
        }

        isFly = true;

        var originalPosition = transform.position;
        var sequence = DOTween.Sequence().OnComplete(Restore);
        sequence.Append(transform.DOMoveY(originalPosition.y + _gemMoveUp, _gemMoveDuration));
        // var playerPosition = Player.Instance.transform.position;
        // sequence.Append(transform.DOMove(playerPosition, _gemMoveDuration));
    }


}
