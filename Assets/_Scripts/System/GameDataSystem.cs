using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSystem
{
    #region WeaponData
    Mk2DataSO _mk2DataSO;
    DronDataSO _dronDataSO;
    FjorginDataSO _fjorginDataSO;
    ElectrodeDataSO _electrodeDataSO;
    ThunderStrokeDataSO _thunderStrokeDataSO;
    BattleItemBoxDataSO _battleItemBoxDataSO;
    NinjaStarBoxDataSO _ninjaStarBoxDataSO;

    public Mk2DataSO GetMk2DataSO()
    {
        return _mk2DataSO;
    }

    public DronDataSO GetDronDataSO()
    {
        return _dronDataSO;
    }

    public FjorginDataSO GetFjorginDataSO()
    {
        return _fjorginDataSO;
    }

    public ElectrodeDataSO GetElectrodeDataSO()
    {
        return _electrodeDataSO;
    }

    public ThunderStrokeDataSO GetThunderStrokeDataSO()
    {
        return _thunderStrokeDataSO;
    }

    public BattleItemBoxDataSO GetBattleItemBoxDataSO()
    {
        return _battleItemBoxDataSO;
    }

    public NinjaStarBoxDataSO GetNinjaStarBoxDataSO()
    {
        return _ninjaStarBoxDataSO;
    }
    #endregion

    EnemyDataSO _enemyDataSO;
    PotionDataSO _potionDataSO;

    public EnemyDataSO GetEnemyDataSO()
    {
        return _enemyDataSO;
    }

    public PotionDataSO GetPotionDataSO()
    {
        return _potionDataSO;
    }

    public void Initialize()
    {
        _mk2DataSO = Resources.Load<Mk2DataSO>(nameof(Mk2DataSO));
        _dronDataSO = Resources.Load<DronDataSO>(nameof(DronDataSO));
        _fjorginDataSO = Resources.Load<FjorginDataSO>(nameof(FjorginDataSO));
        _electrodeDataSO = Resources.Load<ElectrodeDataSO>(nameof(ElectrodeDataSO));
        _thunderStrokeDataSO = Resources.Load<ThunderStrokeDataSO>(nameof(ThunderStrokeDataSO));
        _battleItemBoxDataSO = Resources.Load<BattleItemBoxDataSO>(nameof(BattleItemBoxDataSO));
        _ninjaStarBoxDataSO = Resources.Load<NinjaStarBoxDataSO>(nameof(NinjaStarBoxDataSO));

        _enemyDataSO = Resources.Load<EnemyDataSO>(nameof(EnemyDataSO));

        _potionDataSO = Resources.Load<PotionDataSO>(nameof(PotionDataSO));
    }


}
