using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpGem : RecycleObject
{

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
        sequence.Append(transform.DOMoveY(originalPosition.y + 2, 1));
        sequence.Join(transform.DOScale(Vector3.zero, 0.5f));
    }


}
