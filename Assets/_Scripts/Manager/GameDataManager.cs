using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    GameDataSystem _gameDataSystem = new GameDataSystem();

    public void Initialize()
    {
        _gameDataSystem.Initialize();
    }

    public Mk2DataSO GetMk2DataSO()
    {
        return _gameDataSystem.GetMk2DataSO();
    }

    public DronDataSO GetDronDataSO()
    {
        return _gameDataSystem.GetDronDataSO();
    }

    public FjorginDataSO GetFjorginDataSO()
    {
        return _gameDataSystem.GetFjorginDataSO();
    }

    public ElectrodeDataSO GetElectrodeDataSO()
    {
        return _gameDataSystem.GetElectrodeDataSO();
    }

    public ThunderStrokeDataSO GetThunderStrokeDataSO()
    {
        return _gameDataSystem.GetThunderStrokeDataSO();
    }

    public BattleItemBoxDataSO GetBattleItemBoxDataSO()
    {
        return _gameDataSystem.GetBattleItemBoxDataSO();
    }

}
