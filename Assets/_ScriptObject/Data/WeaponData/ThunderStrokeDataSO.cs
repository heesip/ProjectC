using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(ThunderStrokeDataSO), menuName = "ProjectC/WeaponData/Create ThunderStrokeDataSO")]
public class ThunderStrokeDataSO : ScriptableObject
{
    public readonly float[] ThunderDamages = new float[]
    {
        6, 7, 10
    };

    public readonly WaitForSeconds[] ThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(1.1f), new WaitForSeconds(0.8f),  new WaitForSeconds(0.5f)
    };

    public readonly WaitForSeconds[] AtropineThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(.9f), new WaitForSeconds(0.6f),  new WaitForSeconds(0.2f)
    };
}
