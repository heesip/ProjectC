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
    public readonly int DronRange = 22;

    public readonly float[] DronDamages = new float[]
    {
        0, 4, 5, 7
    };

    public readonly WaitForSeconds[] DronCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(2), new WaitForSeconds(1.5f), new WaitForSeconds(1)
    };

    public readonly float[] AtroPineDronDamages = new float[]
    {
        0, 6, 7, 9
    };

    public readonly WaitForSeconds[] AtropineDronCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(1.5f), new WaitForSeconds(1f), new WaitForSeconds (0.5f)
    };

    public readonly string DronExplain = $"데미지 : {0}, 쿨타임 : {1}";
    #endregion

    #region Electrode
    public readonly int ElectrodeCount = 10;
    public readonly WaitForSeconds AttackDelay = new WaitForSeconds(0.5f);

    public readonly float ElectrodeDamage = 2;
    public readonly float[] ElectrodeSizes = new float[]
    {
        0, 1.0f, 1.25f, 1.5f
    };
    public readonly WaitForSeconds[] ElectrodeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(6), new WaitForSeconds(5), new WaitForSeconds (3)
    };

    public readonly float AtropineElectrodeDamage = 3;
    public readonly WaitForSeconds[] AtropineElectrodeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(5), new WaitForSeconds(4), new WaitForSeconds (2)
    };

    public readonly string ElectrodeExplain = $"전극에테르를 사용한다.";
    #endregion

    #region Fjorgin
    public readonly Vector3 FjorginPosition = new Vector3(1, 2.5f, 0);
    public readonly Vector3 FjorginRotateDirection = new Vector3(0, 0, -315);
    public readonly Vector3 FjorginAttack = Vector3.back * 90;
    public readonly Vector3 FjorginBuffPosition = new Vector3(1.3f, 0, 0);
    public readonly Quaternion FjorginRotation = Quaternion.Euler(0, 0, 45);
    public readonly WaitForSeconds FjorginCoolTime = new WaitForSeconds(3);
    public readonly WaitForSeconds OneSecond = new WaitForSeconds(1);
    public readonly float Fjorgin360RotateDuration = 0.7f;
    public readonly float Fjorgin90RotateDuration = 0.5f;

    public readonly string FjorginExplain = $"피요르긴?!?!";

    #endregion

    #region Mk2 
    public readonly Vector3 Mk2RightPosition = new Vector3(-2f, 0, 0);
    public readonly Vector3 Mk2LeftPosition = new Vector3(2f, 0, 0);
    public readonly Vector3 Mk2RotateDirection = new Vector3(0, 0, -360);
    public readonly Quaternion Mk2Rotation = Quaternion.Euler(0, 0, -90);
    public readonly float Mk2Speed = 1.5f;

    public readonly WaitForSeconds[] Mk2CoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(4), new WaitForSeconds(3), new WaitForSeconds(2)
    };

    public readonly float Mk2Damage = 2.5f;

    public readonly int[] Mk2Counts = new int[]
    {
        0, 3, 4, 6
    };

    public readonly float AtropineMk2Damage = 4f;

    public readonly WaitForSeconds[] AtropineMk2CoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(3), new WaitForSeconds(2), new WaitForSeconds(1f)
    };

    public readonly string Mk2Explain = $"회전하며 공격하는 민국이를 소환한다.";
    #endregion

    #region NinjaStarBox
    public readonly Vector3 ProjectileRotate = new Vector3(0, 0, -1800);

    public readonly float NinjaStarDuration = 1.5f;
    public readonly float NinjaStarSpeed = 6;

    public readonly float[] NinjaStarDamages = new float[]
    {
        0, 2, 3, 5
    };

    public readonly WaitForSeconds[] NinjaStarCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(1.2f), new WaitForSeconds(1f), new WaitForSeconds (.7f)
    };

    public readonly float[] AtroPineNinjaStarDamages = new float[]
    {
        0, 4, 6, 8
    };

    public readonly WaitForSeconds[] AtropineNinjaStarCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(0.9f), new WaitForSeconds(0.6f), new WaitForSeconds (.4f)
    };

    public readonly string NinjaStarBoxExplain = $"가까운 적을 향해 표창을 던진다.";
    #endregion

    #region ThunderStroke
    public readonly float[] ThunderDamages = new float[]
    {
        0, 0.5f, 1, 2
    };

    public readonly WaitForSeconds[] ThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(1.1f), new WaitForSeconds(0.9f),  new WaitForSeconds(0.7f)
    };

    public readonly WaitForSeconds[] AtropineThunderStrokeCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(0), new WaitForSeconds(0.9f), new WaitForSeconds(0.7f),  new WaitForSeconds(0.5f)
    };

    public readonly string ThunderStrokeExplain = $"낙뢰에테르를 사용한다.";
    #endregion
}
