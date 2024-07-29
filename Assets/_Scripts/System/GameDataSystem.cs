using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSystem
{
    WeaponDataSO _weaponDataSO;
    EnemyDataSO _enemyDataSO;
    PotionDataSO _potionDataSO;
    public void Initialize()
    {
        _weaponDataSO = Resources.Load<WeaponDataSO>(nameof(WeaponDataSO));
        _enemyDataSO = Resources.Load<EnemyDataSO>(nameof(EnemyDataSO));
        _potionDataSO = Resources.Load<PotionDataSO>(nameof(PotionDataSO));
    }

    public WeaponDataSO GetWeaponDataSO()
    {
        return _weaponDataSO;
    }

    public EnemyDataSO GetEnemyDataSO()
    {
        return _enemyDataSO;
    }

    public PotionDataSO GetPotionDataSO()
    {
        return _potionDataSO;
    }
}
