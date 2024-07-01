using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Mk2DataSO), menuName = "ProjectC/WeaponData/Create Mk2DataSO")]
public class Mk2DataSO : ScriptableObject
{
    public readonly Vector3 Mk2RightPosition = new Vector3(-2f, 0, 0);
    public readonly Vector3 Mk2LeftPosition = new Vector3(2f, 0, 0);
    public readonly Vector3 Mk2RotateDirection = new Vector3(0, 0, -360);
    public readonly Quaternion Mk2Rotation = Quaternion.Euler(0, 0, -90);
    public readonly float Mk2Speed = 1.5f;

    public readonly WaitForSeconds[] Mk2CoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(5), new WaitForSeconds(4), new WaitForSeconds(3)
    };

    public readonly float Mk2Damage = 2.5f;

    public readonly int[] Mk2Counts = new int[]
    {
        3,4,6
    };


    public readonly float AtropineMk2Damage = 4f;
    public readonly WaitForSeconds[] AtropineMk2CoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(3), new WaitForSeconds(2), new WaitForSeconds(1)
    };

}