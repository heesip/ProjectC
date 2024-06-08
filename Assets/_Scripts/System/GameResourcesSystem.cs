using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcesSystem
{
    PrefabResourcesSO _prefabResourcesSO;
    ImageResourcesSO _imageResourcesSO;
    AnimatorResourcesSO _animatorResourcesSO;

    public void Initialize()
    {
        _prefabResourcesSO = Resources.Load<PrefabResourcesSO>(nameof(PrefabResourcesSO));
        _imageResourcesSO = Resources.Load<ImageResourcesSO>(nameof(ImageResourcesSO));
        _animatorResourcesSO = Resources.Load<AnimatorResourcesSO>(nameof(AnimatorResourcesSO));
    }

    public Enemy GetEnemyPrefab()
    {
        return _prefabResourcesSO.GetEnemyPrefab();
    }

    public ExpGem GetExpGemPrefab()
    {
        return _prefabResourcesSO.GetExpGemPrefab();
    }

    #region Weapon & Bullet
    public Missile GetMissilePrefab()
    {
        return _prefabResourcesSO.GetMissilePrefab();
    }

    public NinjaStar GetNinjaStarPrefab()
    {
        return _prefabResourcesSO.GetNinjaStarPrefab();
    }

    public Thunder GetThunderPrefab()
    {
        return _prefabResourcesSO.GetThunderPrefab();
    }

    public MolotovCocktail GetMolotovCocktailPrefab()
    {
        return _prefabResourcesSO.GetMolotovCocktailPrefab();
    }

    public Flame GetFlamePrefab()
    {
        return _prefabResourcesSO.GetFlamePrefab();
    }

    #endregion

    #region Item
    public Magnet GetMagnetPrefab()
    {
        return _prefabResourcesSO.GetMagnetPrefab();
    }

    public Potion GetPotionPrefab()
    {
        return _prefabResourcesSO.GetPotionPrefab();
    }
    #endregion

    #region Image
    public Sprite GetPotionImage(PotionType potionType)
    {
        return _imageResourcesSO.GetPotionImage(potionType);
    }
    #endregion


    #region AnimatorController
    public RuntimeAnimatorController GetEnemyA_Animator()
    {
        return _animatorResourcesSO.GetEnemyA_Animator();
    }
    public RuntimeAnimatorController GetEnemyB_Animator()
    {
        return _animatorResourcesSO.GetEnemyB_Animator();
    }
    public RuntimeAnimatorController GetEnemyC_Animator()
    {
        return _animatorResourcesSO.GetEnemyC_Animator();
    }
    #endregion

}
