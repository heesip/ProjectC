using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(NinjaStarBoxDataSO), menuName = "ProjectC/WeaponData/Create NinjaStarBoxDataSO")]
public class NinjaStarBoxDataSO : ScriptableObject
{
    public readonly Vector3 ProjectileRotate = new Vector3(0, 0, -1800);

    public readonly float NinjaStarDuration = 1.5f;
    public readonly float NinjaStarSpeed = 6;

    public readonly float[] NinjaStarDamages = new float[]
    {
        2, 3, 5
    };

    public readonly WaitForSeconds[] NinjaStarCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(1.2f), new WaitForSeconds(1f), new WaitForSeconds (.7f)
    };

    public readonly float[] AtroPineNinjaStarDamages = new float[]
    {
        4,6,8
    };

    public readonly WaitForSeconds[] AtropineNinjaStarCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0.9f), new WaitForSeconds(0.6f), new WaitForSeconds (.4f)
    };
}
