using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResourcesSO : ScriptableObject
{
    [SerializeField] Enemy enemyPrefab;


    public Enemy GetEnemyPrefab()
    {
        return enemyPrefab;
    }

}
