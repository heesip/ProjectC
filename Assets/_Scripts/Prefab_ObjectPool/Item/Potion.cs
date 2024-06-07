using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potion : Item
{
    SpriteRenderer _spriteRenderer;
    [SerializeField] PotionType _potionType = PotionType.None;
    int _randomNumber;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void OnStart()
    {
        RandomPotion();
    }

    protected override void ItemFunction()
    {
        Player.Instance.GetPotion(_potionType);
    }

    void RandomPotion()
    {
        _randomNumber = Random.Range(0, 10);
        switch (_randomNumber)
        {
            case 0:
            case 1:
            case 2:
                _potionType = PotionType.EmergencyPotion;
                break;
            case 3:
            case 4:
            case 5:
                _potionType = PotionType.HealPotion;
                break;
            case 6:
            case 7:
                _potionType = PotionType.RareHealPortion;
                break;
            case 8:
                _potionType = PotionType.SpiritPortion;
                break;
            case 9:
                _potionType = PotionType.Atropine;
                break;
            default:
                break;
        }
        _spriteRenderer.sprite = GameResourcesManager.Instance.GetPotionImage(_potionType);
    }

}

