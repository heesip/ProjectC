using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potion : Item
{
    [SerializeField] PotionType _potionType = PotionType.None;
    PotionDataSO _potionDataSO;
    SpriteRenderer _spriteRenderer;
    CapsuleCollider2D _collider;
    [SerializeField] int _healingPoint;
    public int HealingPoint => _healingPoint;

    private void Awake()
    {
        _potionDataSO = GameDataManager.Instance.GetPotionDataSO();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    protected override void OnStart()
    {
        RandomPotion();
    }

    protected override void ItemFunction()
    {
        Player.Instance.Healing(_healingPoint);
    }

    void RandomPotion()
    {
        int randomNumber = Random.Range(0, 10);
        switch (randomNumber)
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
                _potionType = PotionType.RareHealPotion;
                break;
            case 8:
                _potionType = PotionType.SpiritPotion;
                break;
            case 9:
                _potionType = PotionType.Atropine;
                break;
            default:
                break;
        }
        Setting(_potionType);

    }


    void Setting(PotionType potionType)
    {
        _spriteRenderer.sprite = _potionDataSO.PotionImages[(int)potionType];
        _collider.size = _potionDataSO.PotionSizes[(int)potionType];
        _healingPoint = _potionDataSO.HealingPoints[(int)potionType];
    }
}

