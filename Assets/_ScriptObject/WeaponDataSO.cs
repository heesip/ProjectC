using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponDataSO), menuName = "ProjectC/Data/Create WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    #region Dron
    public readonly Vector3 DronRightPosition = new Vector3(-1, 1.5f, 0);
    public readonly Vector3 DronLeftPosition = new Vector3(1, 1.5f, 0);

    public readonly float DronSpeed = 1.2f;
    public readonly int DronCount = 2;
    public readonly int DronRange = 33;

    public readonly float[] DronDamages = new float[]
    {
        0, 3, 5, 7
    };

    public readonly float[] DronCoolTimes = new float[]
    {
        0, 5, 4, 3
    };

    public readonly float[] AtroPineDronDamages = new float[]
    {
        0, 4, 6, 8
    };

    public readonly float[] AtropineDronCoolTimes = new float[]
    {
        0, 4, 3, 2
    };
    #endregion

    public readonly WaitForSeconds AttackDelay = new WaitForSeconds(0.5f);
    #region Electrode
    public readonly int ElectrodeCount = 10;

    public readonly float ElectrodeDamage = 5;
    public readonly float[] ElectrodeSizes = new float[]
    {
        0, 1.5f, 1.7f, 2.2f
    };
    public readonly float[] ElectrodeCoolTimes = new float[]
    {
        0, 5, 4, 2
    };

    public readonly float AtropineElectrodeDamage = 7;
    #endregion

    #region Fjorgin
    public readonly Vector3 FjorginPosition = new Vector3(1, 2.5f, 0);
    public readonly Vector3 FjorginRotateDirection = new Vector3(0, 0, -315);
    public readonly Vector3 FjorginAttack = Vector3.back * 90;
    public readonly Vector3 FjorginBuffPosition = new Vector3(1.3f, 0, 0);
    public readonly Quaternion FjorginRotation = Quaternion.Euler(0, 0, 45);
    public readonly float FjorginCoolTime = 30;
    public readonly float Fjorgin360RotateDuration = 0.7f;
    public readonly float Fjorgin90RotateDuration = 0.5f;
    #endregion

    #region Mk2 
    public readonly Vector3 Mk2RightPosition = new Vector3(-2f, 0, 0);
    public readonly Vector3 Mk2LeftPosition = new Vector3(2f, 0, 0);
    public readonly Vector3 Mk2RotateDirection = new Vector3(0, 0, -360);
    public readonly Quaternion Mk2Rotation = Quaternion.Euler(0, 0, -90);
    public readonly float Mk2Speed = 1.5f;

    public readonly float Mk2Damage = 5;

    public readonly float[] Mk2CoolTimes = new float[]
    {
        0, 5, 4, 3
    };

    public readonly int[] Mk2Counts = new int[]
    {
        0, 3, 4, 6
    };

    public readonly float AtropineMk2Damage = 6;

    public readonly float[] AtropineMk2CoolTimes = new float[]
    {
        0, 4, 3, 2
    };
    #endregion

    #region NinjaStarBox
    public readonly Vector3 ProjectileRotate = new Vector3(0, 0, -1800);

    public readonly float NinjaStarDuration = 1.5f;
    public readonly float NinjaStarSpeed = 6;

    public readonly float[] NinjaStarDamages = new float[]
    {
        0, 8, 9, 11
    };

    public readonly float[] NinjaStarCoolTimes = new float[]
    {
        0, 1.2f, 1f, 0.7f
    };

    public readonly float[] AtroPineNinjaStarDamages = new float[]
    {
        0, 10, 11, 13
    };

    public readonly float[] AtropineNinjaStarCoolTimes = new float[]
    {
        0, 0.9f, 0.6f, 0.4f
    };
    #endregion

    #region ThunderStroke
    public readonly float[] ThunderDamages = new float[]
    {
        0, 4, 5, 7
    };

    public readonly float[] ThunderCoolTimes = new float[]
    {
        0, 1, 0.8f, 0.5f
    };

    public readonly float[] AtropineThunderCoolTimes = new float[]
    {
        0, 0.5f, 1, 0.3f
    };
    #endregion
}
