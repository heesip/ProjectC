using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSystem
{
    Mk2DataSO _mk2DataSO;
    DronDataSO _dronDataSO;

    public void Initialize()
    {
        _mk2DataSO = Resources.Load<Mk2DataSO>(nameof(Mk2DataSO));
        _dronDataSO = Resources.Load<DronDataSO>(nameof(DronDataSO));
    }

    public Mk2DataSO GetMk2DataSO()
    {
        return _mk2DataSO;
    }

    public DronDataSO GetDronDataSO()
    {
        return _dronDataSO;
    }
}
