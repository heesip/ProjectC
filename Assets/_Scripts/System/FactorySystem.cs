using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySystem
{
    public void Initialize(Transform factoryManager)
    {
        _enemyPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetEnemyPrefab(), 100, factoryManager);
        _expGemPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetExpGemPrefab(), 100, factoryManager);
        _missilePrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetMissilePrefab(), 5, factoryManager);
        _ninjaStarPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetNinjaStarPrefab(), 5, factoryManager);
        _thunderPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetThunderPrefab(), 5, factoryManager);
        _molotovCocktailPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetMolotovCocktailPrefab(), 2, factoryManager);
        _flamePrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetFlamePrefab(), 2, factoryManager);
        _fjorginBuffPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetFjorginBuffPrefab(), 1, factoryManager);

        _magnetPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetMagnetPrefab(), 5, factoryManager);
        _potionPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetPotionPrefab(), 5, factoryManager);
        _ninjaStarPiecePrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetNinjaStarPiecePrefab(), 1, factoryManager);
        _itemBoxPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetItemBoxPrefab(), 10, factoryManager);
    }


    ObjectPoolSystem _enemyPrefab;
    ObjectPoolSystem _expGemPrefab;
    ObjectPoolSystem _itemBoxPrefab;
    Enemy _tempEnemy;
    ExpGem _tempExpGem;
    ItemBox _tempItemBox;

    public Enemy GetEnemy()
    {
        _tempEnemy = _enemyPrefab.Get() as Enemy;
        return _tempEnemy;
    }

    public ExpGem GetExpGem()
    {
        _tempExpGem = _expGemPrefab.Get() as ExpGem;
        return _tempExpGem;
    }

    public ItemBox GetItemBox()
    {
        _tempItemBox = _itemBoxPrefab.Get() as ItemBox;
        return _tempItemBox;
    }

    #region Weapon & Bullet
    ObjectPoolSystem _missilePrefab;
    ObjectPoolSystem _ninjaStarPrefab;
    ObjectPoolSystem _thunderPrefab;
    ObjectPoolSystem _molotovCocktailPrefab;
    ObjectPoolSystem _flamePrefab;
    ObjectPoolSystem _fjorginBuffPrefab;
    Missile _tempMissile;
    NinjaStar _tempNinjaStar;
    Thunder _tempThunder;
    MolotovCocktail _tempMolotovCocktail;
    Flame _tempFlame;
    FjorginBuff _tempFjorginBuff;

    public Missile GetMissile()
    {
        _tempMissile = _missilePrefab.Get() as Missile;
        return _tempMissile;
    }

    public NinjaStar GetNinjaStar()
    {
        _tempNinjaStar = _ninjaStarPrefab.Get() as NinjaStar;
        return _tempNinjaStar;
    }

    public Thunder GetThunder()
    {
        _tempThunder = _thunderPrefab.Get() as Thunder;
        return _tempThunder;
    }

    public MolotovCocktail GetMolotovCocktail()
    {
        _tempMolotovCocktail = _molotovCocktailPrefab.Get() as MolotovCocktail;
        return _tempMolotovCocktail;
    }

    public Flame GetFlame()
    {
        _tempFlame = _flamePrefab.Get() as Flame;
        return _tempFlame;
    }

    public FjorginBuff GetFjorginBuff()
    {
        _tempFjorginBuff = _fjorginBuffPrefab.Get() as FjorginBuff;
        return _tempFjorginBuff;
    }

    #endregion

    #region Item
    ObjectPoolSystem _magnetPrefab;
    ObjectPoolSystem _potionPrefab;
    ObjectPoolSystem _ninjaStarPiecePrefab;
    Magnet _tempMagent;
    Potion _tempPotion;
    NinjaStarPiece _tempNinjaStarPiece;

    public Magnet GetMagnet()
    {
        _tempMagent = _magnetPrefab.Get() as Magnet;
        return _tempMagent;
    }

    public Potion GetPotion()
    {
        _tempPotion = _potionPrefab.Get() as Potion;
        return _tempPotion;
    }

    public NinjaStarPiece GetNinjaStarPiece()
    {
        _tempNinjaStarPiece = _ninjaStarPiecePrefab.Get() as NinjaStarPiece;
        return _tempNinjaStarPiece;
    }
    #endregion
}
