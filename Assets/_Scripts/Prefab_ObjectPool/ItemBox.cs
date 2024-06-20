using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ItemBox : RecycleObject
{
    float _duration = 0.2f;
    int _minNumber = 0;
    int _maxNumber = 10;

    void RandomItem()
    {
        int randomNumber = Random.Range(_minNumber, _maxNumber);
        switch (randomNumber)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                Potion potion = FactoryManager.Instance.GetPotion();
                BoxOpen(potion);
                break;
            case 7:
            case 8:
            case 9:
                Magnet magnet = FactoryManager.Instance.GetMagnet();
                BoxOpen(magnet);
                break;
            default:
                break;
        }

    }

    void BoxOpen(Item item)
    {
        item.transform.position = transform.position;
        Vector3 upVector = transform.position + Vector3.up;
        item.transform.DOMove(upVector, _duration);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(AllStrings.Player))
        {
            return;
        }
        RandomItem();
        Restore();
    }
}
