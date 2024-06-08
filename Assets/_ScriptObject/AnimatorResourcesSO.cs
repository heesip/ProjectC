using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AnimatorResourcesSO), menuName = "ProjectC/Create AnimatorResourcesSO")]

public class AnimatorResourcesSO : ScriptableObject
{
    [SerializeField] RuntimeAnimatorController EnemyA_Animator;
    [SerializeField] RuntimeAnimatorController EnemyB_Animator;
    [SerializeField] RuntimeAnimatorController EnemyC_Animator;

    public RuntimeAnimatorController GetEnemyA_Animator()
    {
        return EnemyA_Animator;
    }

    public RuntimeAnimatorController GetEnemyB_Animator()
    {
        return EnemyB_Animator;
    }

    public RuntimeAnimatorController GetEnemyC_Animator()
    {
        return EnemyC_Animator;
    }


}
