using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(ThunderStrokeDataSO), menuName = "ProjectC/WeaponData/Create ThunderStrokeDataSO")]
public class ThunderStrokeDataSO : ScriptableObject
{
    public readonly float X_MinValue = -3f;
    public readonly float X_MaxValue = 3f;
    public readonly float Y_MinValue = -6f;
    public readonly float Y_MaxValue = 6f;
    public readonly float ExceptionMinValue = -0.5f;
    public readonly float ExceptionMaxValue = 0.5f;
    public readonly WaitForSeconds[] ThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(1.2f), new WaitForSeconds(0.9f),  new WaitForSeconds(0.5f)
    };

}
