using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarPiece : Item
{
    protected override void ItemFunction()
    {
        AchieveManager.Instance.GetNinjaStarPiece();
    }
}
