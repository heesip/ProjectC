using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(EnemyDataSO), menuName = "ProjectC/Data/Create EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public RuntimeAnimatorController[] EnemyAnimators;

    // RandomRange 
    public readonly int MinNumber = 0;
    public readonly int MaxNumber = 4;

    // KnockBack
    public readonly float KnockBackRange = 1.5f;
    public readonly WaitForFixedUpdate OneFixedWait = new WaitForFixedUpdate();

    public readonly float[] MaxHealths = new float[]
    {
        7, 10, 15, 20, 30
    };

    public readonly float[] Speeds = new float[]
    {
        1, 1.2f, 1.5f, 1.7f, 2
    };

}

