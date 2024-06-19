using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ItemBox : RecycleObject
{
    float _duration = 0.2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(AllStrings.Player))
        {
            return;
        }

        Potion potion = FactoryManager.Instance.GetPotion();
        potion.transform.position = transform.position;
        Vector3 upVector = transform.position + Vector3.up;
        potion.transform.DOMove(upVector, _duration);
        Restore();
    }
}
