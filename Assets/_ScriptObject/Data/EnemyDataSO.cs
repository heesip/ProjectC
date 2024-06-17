using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(EnemyDataSO), menuName = "ProjectC/WeaponData/Create EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField] RuntimeAnimatorController EnemyA_Animator;
    [SerializeField] RuntimeAnimatorController EnemyB_Animator;
    [SerializeField] RuntimeAnimatorController EnemyC_Animator;

}

  