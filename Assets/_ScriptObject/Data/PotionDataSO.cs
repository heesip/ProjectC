using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PotionDataSO), menuName = "ProjectC/Data/Create PotionDataSO")]
public class PotionDataSO : ScriptableObject
{
    public Sprite[] PotionImages;

    public Vector2[] PotionSizes = new Vector2[]
    {
        Vector2.zero, new Vector2(0.11f, 0.53f), new Vector2(0.2f, 0.53f),
        new Vector2(0.37f, 0.62f), new Vector2(0.72f,0.73f), new Vector2(0.22f, 0.41f)
    };

    public readonly int[] HealingPoints = new int[]
    {
       0, 15, 30, 45, 60, -20
    };

}
