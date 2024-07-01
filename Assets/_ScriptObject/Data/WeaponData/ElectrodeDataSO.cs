using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ElectrodeDataSO), menuName = "ProjectC/WeaponData/Create ElectrodeDataSO")]
public class ElectrodeDataSO : ScriptableObject
{
    public readonly int ElectrodeCount = 10;
    public readonly WaitForSeconds AttackInterval = new WaitForSeconds(0.5f);

    public readonly float ElectrodeDamage = 2;
    public readonly float[] ElectrodeSizes = new float[]
    {
        1.0f, 1.3f, 1.7f
    };
    public readonly WaitForSeconds[] ElectrodeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(6), new WaitForSeconds(5), new WaitForSeconds (3)
    };

    public readonly float AtropineElectrodeDamage = 3;
    public readonly WaitForSeconds[] AtropineElectrodeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(4), new WaitForSeconds(3), new WaitForSeconds (1)
    };
}
