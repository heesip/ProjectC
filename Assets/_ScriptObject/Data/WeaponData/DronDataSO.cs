using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(DronDataSO), menuName = "ProjectC/WeaponData/Create DronDataSO")]
public class DronDataSO : ScriptableObject
{
    public readonly Vector3 DronRightPosition = new Vector3(-1, 1.5f, 0);
    public readonly Vector3 DronLeftPosition = new Vector3(1, 1.5f, 0);

    public readonly float DronSpeed = 1.2f;
    public readonly int DronCount = 2;
    public readonly int DronRange = 22;

    public readonly float[] DronDamages = new float[]
    {
        4,5,7
    };

    public readonly WaitForSeconds[] DronCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(3), new WaitForSeconds(2), new WaitForSeconds(1)
    };

    public readonly float[] AtroPineDronDamages = new float[]
    {
        6,7,9
    };

    public readonly WaitForSeconds[] AtropineDronCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(2.5f), new WaitForSeconds(1.5f), new WaitForSeconds (0.5f)
    };
}