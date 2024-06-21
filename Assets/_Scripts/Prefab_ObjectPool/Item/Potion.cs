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

    private void Awake()
    {
        _potionDataSO = GameDataManager.Instance.GetPotionDataSO();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    protected override void OnStart()
    {
        //RandomPotion();

        _isAtropine = true;
        _potionType = PotionType.Atropine;
        Setting(_potionType);
    }

    protected override void ItemFunction()
    {
        Player.Instance.Healing(_healingPoint, _isAtropine);
    }

    void RandomPotion()
    {
        int randomNumber = Random.Range(0, 10);
        switch (randomNumber)
        {
            case 0:
            case 1:
            case 2:
                _isAtropine = false;
                _potionType = PotionType.EmergencyPotion;
                break;
            case 3:
            case 4:
            case 5:
                _isAtropine = false;
                _potionType = PotionType.HealPotion;
                break;
            case 6:
            case 7:
                _isAtropine = false;
                _potionType = PotionType.RareHealPotion;
                break;
            case 8:
                _isAtropine = false;
                _potionType = PotionType.SpiritPotion;
                break;
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

