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

    public Projectile GetMissilePrefab()
    {
        return _prefabResourcesSO.GetMissilePrefab();
    }

    public Lightning GetLightningPrefab()
    {
        return _prefabResourcesSO.GetLightningPrefab();
    }

}
