using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ElectrodeDataSO), menuName = "ProjectC/WeaponData/Create ElectrodeDataSO")]
public class ElectrodeDataSO : ScriptableObject
{
    public readonly int ElectrodeCount = 10;
    public readonly WaitForSeconds AttackInterval = new WaitForSeconds(0.5f);

    public readonly float[] ElectrodeDamages = new float[]
    {
        2, 3, 5
    };

    public readonly float[] ElectrodeSizes = new float[]
    {
        1.0f, 1.5f, 2f
    };

    public readonly WaitForSeconds[] ElectrodeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(6), new WaitForSeconds(5), new WaitForSeconds (3)
    };
}
