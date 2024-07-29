using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcesSystem
{
    PrefabResourcesSO _prefabResourcesSO;
    UIPrefabResourcesSO _uIPrefabResourcesSO;

    public void Initialize()
    {
        _prefabResourcesSO = Resources.Load<PrefabResourcesSO>(nameof(PrefabResourcesSO));
        _uIPrefabResourcesSO = Resources.Load<UIPrefabResourcesSO>(nameof(UIPrefabResourcesSO));
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

    #region UIBox
    public SelectBoxType DronBox()
    {
        return _uIPrefabResourcesSO.DronBox();
    }

    public SelectBoxType ElectrodeBox()
    {
        return _uIPrefabResourcesSO.ElectrodeBox();
    }

    public SelectBoxType FjorginBox()
    {
        return _uIPrefabResourcesSO.FjorginBox();
    }

    public SelectBoxType Mk2Box()
    {
        return _uIPrefabResourcesSO.Mk2Box();
    }

    public SelectBoxType NinjaStarBox()
    {
        return _uIPrefabResourcesSO.NinjaStarBox();
    }

    public SelectBoxType ThunderBox()
    {
        return _uIPrefabResourcesSO.ThunderBox();
    }

    public SelectBoxType DonePieceBox()
    {
        return _uIPrefabResourcesSO.DonePieceBox();
    }

    public SelectBoxType AtropineBox()
    {
        return _uIPrefabResourcesSO.AtropineBox();
    }

    public SelectBoxType EmergencyBox()
    {
        return _uIPrefabResourcesSO.EmergencyBox();
    }

    public SelectBoxType HealPotionBox()
    {
        return _uIPrefabResourcesSO.HealPotionBox();
    }
    #endregion
}
