using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ItemBox : RecycleObject
{
    Collider2D _collider2D;
    float _duration = 0.2f;
    int _minNumber = 0;
    int _maxNumber = 10;

    void DropTable()
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
            case 8:
                Magnet magnet = FactoryManager.Instance.GetMagnet();
                BoxOpen(magnet);
                break;
            case 7:
            case 9:
                MolotovCocktail molotovCocktail = FactoryManager.Instance.GetMolotovCocktail();
                BoxOpen(molotovCocktail);
                break;
            default:
                break;
        }

    }

    void BoxOpen(Item item)
    {
        item.transform.position = transform.position;
        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 direction = (transform.position - playerPosition).normalized;
        Vector3 target = gameObject.transform.position + direction;
        item.transform.DOMove(target, _duration);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(AllStrings.Player))
        {
            return;
        }
        DropTable();
        Restore();
    }

}
