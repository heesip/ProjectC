using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : Singleton<AchieveManager>
{
    [SerializeField] AchieveSystem _achieveSystem = new AchieveSystem();
    public bool IsDonePieceAchieve => _achieveSystem.IsDonePieceAchieve;
    public bool IsDonePieceActive=> _achieveSystem.IsDonePieceActive;
    public bool IsMadnessAchieve => _achieveSystem.IsMadnessAchieve;
    public bool IsMadnessTitleActive => _achieveSystem.IsMadnessTitleActive;
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

    public void GetMadnessTitleAchieve()
    {
        _achieveSystem.GetMadnessAchieve();
    }

    public void SaveTitleAchtive()
    {
        _achieveSystem.SaveMadnessTitleActive();
    }

}
