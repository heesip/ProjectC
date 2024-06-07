using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potion : Item
{
    
   public PotionType _potionType = PotionType.None;

    protected override void OnStart()
    {
        //_potionType = PotionType.EmergencyPotion;
    }

    protected override void ItemFunction()
    {
        Player.Instance.GetPotion(_potionType);
    }
}

public enum PotionType
{
    None,
    EmergencyPotion,
    HealPotion,
    RareHealPortion,
    Spirit,
    Atropine
}