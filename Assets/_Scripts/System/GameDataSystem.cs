using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSystem
{
    Mk2DataSO _mk2DataSO;
    DronDataSO _dronDataSO;
    FjorginDataSO _fjorginDataSO;
    ElectrodeDataSO _electrodeDataSO;

    public void Initialize()
    {
        _mk2DataSO = Resources.Load<Mk2DataSO>(nameof(Mk2DataSO));
        _dronDataSO = Resources.Load<DronDataSO>(nameof(DronDataSO));
        _fjorginDataSO = Resources.Load<FjorginDataSO>(nameof(FjorginDataSO));
        _electrodeDataSO = Resources.Load<ElectrodeDataSO>(nameof(ElectrodeDataSO));

    }

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
}
