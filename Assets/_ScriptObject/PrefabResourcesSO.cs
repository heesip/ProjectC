using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PrefabResourcesSO), menuName = "ProjectC/Create PrefabResourcesSO")]

public class PrefabResourcesSO : ScriptableObject
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] ExpGem _expGemPrefab;
    [SerializeField] Projectile _missilePrefab;
    [SerializeField] Projectile _ninjaStarPrefab;
    [SerializeField] Lightning _lightningPrefab;

    public Enemy GetEnemyPrefab()
    {
        return _enemyPrefab;
    }

    public ExpGem GetExpGemPrefab()
    {
        return _expGemPrefab;
    }

    public Projectile GetMissilePrefab()
    {
        return _missilePrefab;
    }

    public Projectile GetNinjaStar()
    {
        return _ninjaStarPrefab;
    }

    public Lightning GetLightningPrefab()
    {
        return _lightningPrefab;
    }

}
