using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpGem : RecycleObject
{
    //Temp Code
    [SerializeField] float _gemMoveUp = 2;
    [SerializeField] float _gemMoveDuration = 1;
    [SerializeField] float _gemDisappearDuration = 0.5f;
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
        var originalPosition = transform.position;
        var playerPosition = Player.Instance.transform.position;
        var sequence = DOTween.Sequence().OnComplete(Restore);
        sequence.Append(transform.DOMoveY(originalPosition.y + _gemMoveUp, _gemMoveDuration));
        sequence.Join(transform.DOScale(Vector3.zero, _gemDisappearDuration));
    }


}
