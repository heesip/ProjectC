using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : Singleton<AchieveManager>
{
    [SerializeField] AchieveSystem _achieveSystem = new AchieveSystem();
    public bool IsRareNinjaStar => _achieveSystem.IsRareNinjaStar;
    public bool IsAtropineTitle => _achieveSystem.IsAtropineTitle;

    public void Load()
    {
        _achieveSystem.Load();
    }

    public void Save()
    {
        _achieveSystem.Save();
    }

    public void GetNinjaStarPiece()
    {
        _achieveSystem.GetNinjaStarPiece();
    }

    public void GetAtropineTitle()
    {
        _achieveSystem.GetAtropineTitle();
    }

}
