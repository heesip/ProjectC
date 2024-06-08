using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcesManager : Singleton<GameResourcesManager>
{
    GameResourcesSystem _gameResourcesSystem = new GameResourcesSystem();

    public void Initialize()
    {
        _gameResourcesSystem.Initialize();
    }

    public Enemy GetEnemyPrefab()
    {
        return _gameResourcesSystem.GetEnemyPrefab();
    }

    public ExpGem GetExpGemPrefab()
    {
        return _gameResourcesSystem.GetExpGemPrefab();
    }

    public Missile GetMissilePrefab()
    {
        return _gameResourcesSystem.GetMissilePrefab();
    }

    public NinjaStar GetNinjaStarPrefab()
    {
        return _gameResourcesSystem.GetNinjaStarPrefab();
    }

    public Thunder GetThunderPrefab()
    {
        return _gameResourcesSystem.GetThunderPrefab();
    }

    public MolotovCocktail GetMolotovCocktailPrefab()
    {
        return _gameResourcesSystem.GetMolotovCocktailPrefab();
    }

    public Flame GetFlamePrefab()
    {
        return _gameResourcesSystem.GetFlamePrefab();
    }

    public Magnet GetMagnetPrefab()
    {
        return _gameResourcesSystem.GetMagnetPrefab();
    }

    public Potion GetPotionPrefab()
    {
        return _gameResourcesSystem.GetPotionPrefab();
    }

    #region PotionImage
    public Sprite GetPotionImage(PotionType potionType)
    {
        return _gameResourcesSystem.GetPotionImage(potionType);
    }
    #endregion


    public RuntimeAnimatorController GetEnemyA_Animator()
    {
        return _gameResourcesSystem.GetEnemyA_Animator();
    }
    public RuntimeAnimatorController GetEnemyB_Animator()
    {
        return _gameResourcesSystem.GetEnemyB_Animator();
    }
    public RuntimeAnimatorController GetEnemyC_Animator()
    {
        return _gameResourcesSystem.GetEnemyC_Animator();
    }

}
