using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : Singleton<AchieveManager>
{
    [SerializeField] AchieveSystem _achieveSystem = new AchieveSystem();
    public bool IsDonePieceAchieve => _achieveSystem.IsDonePieceAchieve;
    public bool IsDonePieceActive=> _achieveSystem.IsDonePieceActive;
    public bool IsAtropineTitleAchieve => _achieveSystem.IsAtropineTitleAchieve;
    public bool IsAtropineTitleActive => _achieveSystem.IsAtropineTitleActive;
    public int OnePiece => _achieveSystem.OnePiece;
    

    public void Load()
    {
        _achieveSystem.Load();
    }

    public void Save()
    {
        _achieveSystem.Save();
    }

    public void GetDonePieceAchieve()
    {
        _achieveSystem.GetDonePieceAchieve();
    }

    public void SaveDonePieceActive()
    {
        _achieveSystem.SaveDonePieceActive();
    }

    public void GetAtropineTitleAchieve()
    {
        _achieveSystem.GetAtropineTitleAchieve();
    }

    public void SaveTitleAchtive()
    {
        _achieveSystem.SaveTitleActive();
    }

}
