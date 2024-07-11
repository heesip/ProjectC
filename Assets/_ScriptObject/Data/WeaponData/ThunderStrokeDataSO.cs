using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(ThunderStrokeDataSO), menuName = "ProjectC/WeaponData/Create ThunderStrokeDataSO")]
public class ThunderStrokeDataSO : ScriptableObject
{
    public readonly float[] ThunderDamages = new float[]
    {
        2.5f, 3, 4
    };

    public readonly WaitForSeconds[] ThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(1.1f), new WaitForSeconds(0.9f),  new WaitForSeconds(0.7f)
    };

    public readonly WaitForSeconds[] AtropineThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0.9f), new WaitForSeconds(0.7f),  new WaitForSeconds(0.5f)
    };
}
