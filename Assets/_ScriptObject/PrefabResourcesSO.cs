using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PrefabResourcesSO), menuName ="ProjectC/Create PrefabResourcesSO")]

public class PrefabResourcesSO : ScriptableObject
{
    [SerializeField] Enemy _enemyPrefab;


    public Enemy GetEnemyPrefab()
    {
        return _enemyPrefab;
    }

}
