using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : Singleton<AchieveManager>
{
    [SerializeField] AchieveSystem _achieveSystem = new AchieveSystem();

    public int OnePiece => _achieveSystem.OnePiece;
    public bool IsAchieveDonePiece => _achieveSystem.IsAchieveDonePiece;
    public bool IsActiveDonePiece => _achieveSystem.IsActiveDonePiece;

    public bool IsAchieveMadness => _achieveSystem.IsAchieveMadness;
    public bool IsActiveTitleMadness => _achieveSystem.IsActiveTitleMadness;

    public bool IsAchieveClearEyes => _achieveSystem.IsAchieveClearEyes;
    public bool IsActiveTitleClearEyes => _achieveSystem.IsActiveTitleClearEyes;
    public bool IsAchieveHidden => _achieveSystem.IsAchieveHidden;

    public bool IsAchieveApple => _achieveSystem.IsAchieveApple;


    public void Load()
    {
        _achieveSystem.Load();
    }

    public void GetDonePieceAchieve()
    {
        _achieveSystem.GetDonePieceAchieve();
        NoticeUI.Instance.NoticeStopCoHandle();
        NoticeUI.Instance.GetPiece();
    }

    public void SaveDonePieceActive()
    {
        _achieveSystem.SaveDonePieceActive();
    }

    public void GetMadnessTitleAchieve()
    {
        _achieveSystem.GetMadnessAchieve();
    }

    public void SaveMadnessTitleActive()
    {
        _achieveSystem.SaveMadnessTitleActive();
    }

    public void GetClearEyesAchieve()
    {
        _achieveSystem.GetClearEyesAchieve();
    }

    public void SaveClearEyesTitleActive()
    {
        _achieveSystem.SaveClearEyesTitleActive();
    }

    public void GetHiddenAchieve()
    {
        _achieveSystem.GetHiddenAchieve();
    }

    public void GetAppleAchieve()
    {
        _achieveSystem.GetAppleAchieve();
    }
}
