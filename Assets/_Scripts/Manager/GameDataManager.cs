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
  
    public WeaponDataSO GetWeaponDataSO()
    {
        return _gameDataSystem.GetWeaponDataSO();
    }

    public EnemyDataSO GetEnemyDataSO()
    {
        return _gameDataSystem.GetEnemyDataSO();
    }

    public PotionDataSO GetPotionDataSO()
    {
        return _gameDataSystem.GetPotionDataSO();
    }
}
