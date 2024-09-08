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
    bool _isAtropine;
    public int HealingPoint => _healingPoint;

    void Awake()
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
        Player.Instance.Healing(_healingPoint, _isAtropine);
    }

    void RandomPotion()
    {
        int randomNumber = Random.Range(0, 10);
        _isAtropine = false;
        switch (randomNumber)
        {
            case 0:
            case 1:
            case 2:
                _potionType = PotionType.EmergencyPotion;
                break;
            case 3:
            case 4:
                _potionType = PotionType.HealPotion;
                break;
            case 5:
                _potionType = PotionType.RareHealPotion;
                break;
            case 6:
                _potionType = PotionType.SpiritPotion;
                break;
            case 7:
            case 8:
            case 9:
                _isAtropine = true;
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

