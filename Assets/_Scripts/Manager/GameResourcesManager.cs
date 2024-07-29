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

    #region UIBox
    public SelectBoxType DronBox()
    {
        return _gameResourcesSystem.DronBox();
    }
    public SelectBoxType ElectrodeBox()
    {
        return _gameResourcesSystem.ElectrodeBox();
    }

    public SelectBoxType FjorginBox()
    {
        return _gameResourcesSystem.FjorginBox();
    }

    public SelectBoxType Mk2Box()
    {
        return _gameResourcesSystem.Mk2Box();
    }

    public SelectBoxType NinjaStarBox()
    {
        return _gameResourcesSystem.NinjaStarBox();
    }

    public SelectBoxType ThunderBox()
    {
        return _gameResourcesSystem.ThunderBox();
    }

    public SelectBoxType DonePieceBox()
    {
        return _gameResourcesSystem.DonePieceBox();
    }

    public SelectBoxType AtropineBox()
    {
        return _gameResourcesSystem.AtropineBox();
    }

    public SelectBoxType EmergencyBox()
    {
        return _gameResourcesSystem.EmergencyBox();
    }

    public SelectBoxType HealPotionBox()
    {
        return _gameResourcesSystem.HealPotionBox();
    }
    #endregion
}
