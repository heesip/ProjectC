using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcesSystem
{
    PrefabResourcesSO _prefabResourcesSO;

    public void Initialize()
    {
        _prefabResourcesSO = Resources.Load<PrefabResourcesSO>(nameof(PrefabResourcesSO));
    }

    public Enemy GetEnemyPrefab()
    {
        return _prefabResourcesSO.GetEnemyPrefab();
    }

    public ExpGem GetExpGemPrefab()
    {
        return _prefabResourcesSO.GetExpGemPrefab();
    }

    public ItemBox GetItemBoxPrefab()
    {
        return _prefabResourcesSO.GetItemBoxPrefab();
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

    public FjorginBuff GetFjorginBuffPrefab()
    {
         return _prefabResourcesSO.GetFjorginBuffPrefab();
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

    public NinjaStarPiece GetNinjaStarPiecePrefab()
    {
        return _prefabResourcesSO.GetNinjaStarPiecePrefab();
    }
    #endregion

}
