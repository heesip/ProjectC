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

    public ItemBox GetItemBoxPrefab()
    {
        return _gameResourcesSystem.GetItemBoxPrefab();
    }

    #region Weapon & Bullet
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

    public FjorginBuff GetFjorginBuffPrefab()
    {
        return _gameResourcesSystem.GetFjorginBuffPrefab();
    }

    #endregion

    #region Item
    public Magnet GetMagnetPrefab()
    {
        return _gameResourcesSystem.GetMagnetPrefab();
    }

    public Potion GetPotionPrefab()
    {
        return _gameResourcesSystem.GetPotionPrefab();
    }

    public NinjaStarPiece GetNinjaStarPiecePrefab()
    {
        return _gameResourcesSystem.GetNinjaStarPiecePrefab();
    }
    #endregion

}
