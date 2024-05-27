using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySystem
{
    ObjectPoolSystem _enemyPrefab;
    ObjectPoolSystem _expGemPrefab;
    ObjectPoolSystem _missilePrefab;
    ObjectPoolSystem _ninjaStarPrefab;
    ObjectPoolSystem _thunderPrefab;

    Enemy _tempEnemy;
    ExpGem _tempExpGem;
    Missile _tempMissile;
    NinjaStar _tempNinjaStar;
    Thunder _tempThunder;

    public void Initialize(Transform factoryManager)
    {
        _enemyPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetEnemyPrefab(), 100, factoryManager);
        _expGemPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetExpGemPrefab(), 100, factoryManager);
        _missilePrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetMissilePrefab(), 10, factoryManager);
        _ninjaStarPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetNinjaStarPrefab(), 10, factoryManager);
        _thunderPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetThunderPrefab(), 10, factoryManager);
    }

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
}
