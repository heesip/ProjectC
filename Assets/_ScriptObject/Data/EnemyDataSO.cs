using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(EnemyDataSO), menuName = "ProjectC/Data/Create EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public RuntimeAnimatorController[] EnemyAnimators;

    public readonly int MinRandomNumber = 0;
    public readonly int MaxRandomNumber = 4;
    public readonly float KnockBackRange = 1.5f;
    public readonly WaitForFixedUpdate OneFixedWait = new WaitForFixedUpdate();

    public readonly float[] Speeds = new float[]
    {
        1, 1.2f, 1.5f, 1.7f, 2
    };

}

