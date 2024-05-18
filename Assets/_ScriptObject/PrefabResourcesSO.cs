using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PrefabResourcesSO), menuName = "ProjectC/Create PrefabResourcesSO")]

public class PrefabResourcesSO : ScriptableObject
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] ExpGem _expGemPrefab;
    [SerializeField] Missile _missilePrefab;
    [SerializeField] NinjaStar _ninjaStarPrefab;
    [SerializeField] Lightning _lightningPrefab;

    public Enemy GetEnemyPrefab()
    {
        return _enemyPrefab;
    }

    public ExpGem GetExpGemPrefab()
    {
        return _expGemPrefab;
    }

    public Missile GetMissilePrefab()
    {
        return _missilePrefab;
    }

    public NinjaStar GetNinjaStarPrefab()
    {
        return _ninjaStarPrefab;
    }

    public Lightning GetLightningPrefab()
    {
        return _lightningPrefab;
    }

}
