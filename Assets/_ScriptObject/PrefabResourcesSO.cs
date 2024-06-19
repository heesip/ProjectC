using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PrefabResourcesSO), menuName = "ProjectC/Create PrefabResourcesSO")]

public class PrefabResourcesSO : ScriptableObject
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] ExpGem _expGemPrefab;
    [SerializeField] ItemBox _itemBoxPrefab;

    public Enemy GetEnemyPrefab()
    {
        return _enemyPrefab;
    }

    public ExpGem GetExpGemPrefab()
    {
        return _expGemPrefab;
    }

    public ItemBox GetItemBoxPrefab()
    {
        return _itemBoxPrefab;
    } 

    #region Weapon & Bullet
    [SerializeField] Missile _missilePrefab;
    [SerializeField] NinjaStar _ninjaStarPrefab;
    [SerializeField] Thunder _thunderPrefab;
    [SerializeField] MolotovCocktail _molotovCocktailPrefab;
    [SerializeField] Flame _flamePrefab;

    public Missile GetMissilePrefab()
    {
        return _missilePrefab;
    }

    public NinjaStar GetNinjaStarPrefab()
    {
        return _ninjaStarPrefab;
    }

    public Thunder GetThunderPrefab()
    {
        return _thunderPrefab;
    }

    public MolotovCocktail GetMolotovCocktailPrefab()
    {
        return _molotovCocktailPrefab;
    }

    public Flame GetFlamePrefab()
    {
        return _flamePrefab;
    }
    #endregion

    #region Item
    [SerializeField] Magnet _magnetPrefab;
    [SerializeField] Potion _potionPrefab;

    public Magnet GetMagnetPrefab()
    {
        return _magnetPrefab;
    }

    public Potion GetPotionPrefab()
    {
        return _potionPrefab;
    }
    #endregion

}
