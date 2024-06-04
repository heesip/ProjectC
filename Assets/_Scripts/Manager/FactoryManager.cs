using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : Singleton<FactoryManager>
{
    FactorySystem _factorySystem = new FactorySystem();

    public void Initialize()
    {
        _factorySystem.Initialize(transform);
    }

    public Enemy GetEnemy()
    {
        return _factorySystem.GetEnemy();
    }

    public ExpGem GetExpGem()
    {
        return _factorySystem.GetExpGem();
    }

    public Missile GetMissile()
    {
        return _factorySystem.GetMissile();
    }

    public NinjaStar GetNinjaStar()
    {
        return _factorySystem.GetNinjaStar();
    }

    public Thunder GetThunder()
    {
        return _factorySystem.GetThunder();
    }

    public MolotovCocktail GetMolotovCocktail()
    {
        return _factorySystem.GetMolotovCocktail();
    }

    public Flame GetFlame()
    {
        return _factorySystem.GetFlame();
    }

    public Magnet GetMagnet()
    {
        return _factorySystem.GetMagnet();
    }
}
