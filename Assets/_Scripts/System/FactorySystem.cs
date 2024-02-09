using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySystem
{
    ObjectPoolSystem _enemyPrefab;
    ObjectPoolSystem _expGemPrefab;

    Enemy _tempEnemy;
    ExpGem _tempExpGem;

    public void Initialize(Transform factoryManager)
    {
        _enemyPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetEnemyPrefab(), 1, factoryManager);
        _expGemPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetExpGemPrefab(), 1, factoryManager);
        
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
}
