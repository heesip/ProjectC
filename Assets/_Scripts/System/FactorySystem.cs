using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySystem
{
    ObjectPoolSystem _enemyPrefab;
    Enemy _tempEnemy;
    public void Initialize(Transform factoryManager)
    {
        _enemyPrefab = new ObjectPoolSystem(GameResourcesManager.Instance.GetEnemyPrefab(), 1, factoryManager);
    }


    public Enemy GetEnemy()
    {
        _tempEnemy = _enemyPrefab.Get() as Enemy;
        return _tempEnemy;
    }
}
