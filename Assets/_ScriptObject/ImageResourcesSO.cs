using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ImageResourcesSO), menuName = "ProjectC/Create ImageResourcesSO")]

public class ImageResourcesSO : ScriptableObject
{
    [SerializeField] Sprite _emergencyPotionImage;
    [SerializeField] Sprite _healPotionImage;
    [SerializeField] Sprite _rareHealPotionImage;
    [SerializeField] Sprite _spiritPotionImage;
    [SerializeField] Sprite _atropineImage;

    public Sprite GetPotionImage(PotionType potionType)
    {
        switch (potionType)
        {
            case PotionType.EmergencyPotion:
                return _emergencyPotionImage;
            case PotionType.HealPotion:
                return _healPotionImage;
            case PotionType.RareHealPotion:
                return _rareHealPotionImage;
            case PotionType.SpiritPotion:
                return _spiritPotionImage;
            case PotionType.Atropine:
                return _atropineImage;
            default:
                return null;
        }
    }
}
