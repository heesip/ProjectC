using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerInfoSystem
{
    float _maxHealth;
    [SerializeField] float _health;
    public float Health => _health;
    [SerializeField] bool _isDead;
    public bool IsDead => _isDead;


    public void Initialize()
    {
        _isDead = false;
        _maxHealth = 100;
        _health = _maxHealth;
    }

    public void OnDamage()
    {
        _health -= Time.deltaTime * 10;
        if(_health <= 0)
        {
            _isDead = true;
        }
    }

    public void GetPotion(PotionType potionType)
    {
        switch (potionType)
        {
            case PotionType.None:
                break;
            case PotionType.EmergencyPotion:
                _health += 15;
                break;
            case PotionType.HealPotion:
                _health += 30;
                break;
            case PotionType.RareHealPortion:
                _health += 45;
                break;
            case PotionType.SpiritPortion:
                _health += 60;
                break;
            case PotionType.Atropine:
                _health -= 20;
                break;
            default:
                break;
        }
    }
}
