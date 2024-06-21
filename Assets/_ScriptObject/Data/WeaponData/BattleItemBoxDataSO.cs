using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BattleItemBoxDataSO), menuName = "ProjectC/WeaponData/Create BattleItemBoxDataSO")]
public class BattleItemBoxDataSO : ScriptableObject
{
    public readonly Vector3 ProjectileRotate = new Vector3(0, 0, -1800);

    public readonly float NinjaStarDuration = 1.5f;
    public readonly float NinjaStarSpeed = 6;

    public readonly float MolotovCocktailRange = 2.5f;
    public readonly float MolotovCocktailDuration = 3;
    public readonly WaitForSeconds FlameCoolTime = new WaitForSeconds(0.5f);
    public readonly float FlameDuration = 5;

    public readonly float[] NinjaStarDamages = new float[]
    {
        2, 3, 5
    };

    public readonly WaitForSeconds[] NinjaStarCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(1.5f), new WaitForSeconds(1f), new WaitForSeconds (.5f)
    };


    public readonly WaitForSeconds[] MolotovCocktailCoolTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(15f), new WaitForSeconds(12f), new WaitForSeconds (9f)
    };

    public readonly float[] FlameDamages = new float[]
    {
        4, 6, 10
    };

    public readonly float AtroPineNinjaStarDamage = 7;
    public readonly WaitForSeconds AtropineNinjaStarCoolTime = new WaitForSeconds(0.1f);

    public readonly float AtroPineFlameDamage = 999999;
    public readonly WaitForSeconds AtropineMolotovCocktailCoolTime = new WaitForSeconds(3f);

}
