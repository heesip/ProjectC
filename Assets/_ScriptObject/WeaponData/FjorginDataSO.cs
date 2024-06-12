using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(FjorginDataSO), menuName = "ProjectC/WeaponData/Create FjorginDataSO")]
public class FjorginDataSO : ScriptableObject
{
    public readonly Vector3 FjorginPosition = new Vector3(1, 2.5f, 0);
    public readonly Vector3 FjorginRotateDirection = new Vector3(0, 0, -315);
    public readonly Vector3 FjorginBuff = Vector3.back * 90;
    public readonly Quaternion FjorginRotation = Quaternion.Euler(0, 0, 45);
    public readonly WaitForSeconds FjorginCoolTime = new WaitForSeconds(10);
    public readonly WaitForSeconds OneSecond = new WaitForSeconds(1);
    public readonly float Fjorgin360RotateDuration = 0.7f;
    public readonly float Fjorgin90RotateDuration = 0.5f;

}
