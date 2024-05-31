using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcesManager : Singleton<GameResourcesManager>
{
    GameResourcesSystem _gameResourcesSystem = new GameResourcesSystem();

    public void Initialize()
    {
        _gameResourcesSystem.Initialize();
    }

    public Enemy GetEnemyPrefab()
    {
        return _gameResourcesSystem.GetEnemyPrefab();
    }

    public ExpGem GetExpGemPrefab()
    {
        return _gameResourcesSystem.GetExpGemPrefab();
    }

    public Missile GetMissilePrefab()
    {
        return _gameResourcesSystem.GetMissilePrefab();
    }

    public NinjaStar GetNinjaStarPrefab()
    {
        return _gameResourcesSystem.GetNinjaStarPrefab();
    }

    public Thunder GetThunderPrefab()
    {
        return _gameResourcesSystem.GetThunderPrefab();
    }

    public MolotovCocktail GetMolotovCocktailPrefab()
    {
        return _gameResourcesSystem.GetMolotovCocktailPrefab();
    }

    public Flame GetFlamePrefab()
    {
        return _gameResourcesSystem.GetFlamePrefab();
    }
}
