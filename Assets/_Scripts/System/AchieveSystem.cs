using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AchieveSystem
{
    public void Load()
    {
        LoadPiece();
        LoadAchieve(ActiveDonePiece, out _isActiveDonePiece);
        LoadAchieve(AchieveMadness, out _isAchieveMadness);
        LoadAchieve(AchieveClearEyes, out _isAchieveClearEyes);
        LoadAchieve(AchieveHidden, out _isAchieveHiiden);
        LoadTitleActive(ActiveTitleMadness, out _isActiveTitleMadness);
        LoadTitleActive(ActiveTitleClearEyes, out _isActiveTitileClearEyes);
    }

    bool SaveTitleActive(string key, bool achieve, bool isActive)
    {
        if (!achieve)
        {
            return isActive;
        }

        if (key == ActiveTitleMadness && _isActiveTitileClearEyes)
        {
            _isActiveTitileClearEyes = false;
            PlayerPrefs.SetInt(ActiveTitleClearEyes, Convert.ToInt16(_isActiveTitileClearEyes));
        }
        else if (key == ActiveTitleClearEyes && _isActiveTitleMadness)
        {
            _isActiveTitleMadness = false;
            PlayerPrefs.SetInt(ActiveTitleMadness, Convert.ToInt16(_isActiveTitleMadness));
        }

        isActive = !isActive;
        PlayerPrefs.SetInt(key, Convert.ToInt16(isActive));
        return isActive;
    }

    void SaveAchieve(string key, bool achieve)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt16(achieve));
    }

    void LoadAchieve(string key, out bool achieve)
    {
        achieve = Convert.ToBoolean(PlayerPrefs.GetInt(key));
    }

    bool SaveActiveToggle(string key, bool achieve, bool isActive)
    {
        if (!achieve)
        {
            return isActive;
        }

        isActive = !isActive;
        PlayerPrefs.SetInt(key, Convert.ToInt16(isActive));
        return isActive;
    }

    void LoadTitleActive(string key, out bool titleActive)
    {
        titleActive = Convert.ToBoolean(PlayerPrefs.GetInt(key));
    }
    #region DonePiece
    readonly string Piece = "Piece";
    readonly string AchieveDonePiece = "DonePieceAchieve";
    readonly string ActiveDonePiece = "DonePieceActive";

    int _onePiece;
    public int OnePiece => _onePiece;
    readonly int _donePiece = 4;

    bool _isAchieveDonePiece;
    public bool IsAchieveDonePiece => _isAchieveDonePiece;

    bool _isActiveDonePiece;
    public bool IsActiveDonePiece => _isActiveDonePiece;

    public void GetDonePieceAchieve()
    {
        if (DonePiece())
        {
            return;
        }

        _onePiece++;
        _isAchieveDonePiece = DonePiece();
        PlayerPrefs.SetInt(AchieveDonePiece, Convert.ToInt16(_isAchieveDonePiece));
        SavePiece();
    }

    public void SaveDonePieceActive()
    {
        _isActiveDonePiece = SaveActiveToggle(ActiveDonePiece, _isAchieveDonePiece, _isActiveDonePiece);
    }

    bool DonePiece()
    {
        return _onePiece == _donePiece;
    }

    void SavePiece()
    {
        PlayerPrefs.SetInt(Piece, _onePiece);
    }

    void LoadPiece()
    {
        _onePiece = PlayerPrefs.GetInt(Piece);
        LoadAchieve(AchieveDonePiece, out _isAchieveDonePiece);
    }
    #endregion

    #region Madness
    readonly string AchieveMadness = "MadnessAchieve";
    readonly string ActiveTitleMadness = "MadnessTitleActive";

    bool _isAchieveMadness;
    public bool IsAchieveMadness => _isAchieveMadness;

    bool _isActiveTitleMadness;
    public bool IsActiveTitleMadness => _isActiveTitleMadness;

    public void GetMadnessAchieve()
    {
        _isAchieveMadness = true;
        SaveAchieve(AchieveMadness, _isAchieveMadness);
    }

    public void SaveMadnessTitleActive()
    {
        _isActiveTitleMadness = SaveTitleActive(ActiveTitleMadness, _isAchieveMadness, _isActiveTitleMadness);
    }
    #endregion

    #region ClearEyes
    readonly string AchieveClearEyes = "ClearEyesAchieve";
    readonly string ActiveTitleClearEyes = "ClearEyesTitleActive";
    readonly string AchieveHidden = "Hidden";

    bool _isAchieveClearEyes;
    public bool IsAchieveClearEyes => _isAchieveClearEyes;

    bool _isActiveTitileClearEyes;
    public bool IsActiveTitleClearEyes => _isActiveTitileClearEyes;

    bool _isAchieveHiiden;
    public bool IsAchieveHidden => _isAchieveHiiden;

    public void GetClearEyesAchieve()
    {
        _isAchieveClearEyes = true;
        SaveAchieve(AchieveClearEyes, _isAchieveClearEyes);
    }

    public void SaveClearEyesTitleActive()
    {
        _isActiveTitileClearEyes = SaveTitleActive(ActiveTitleClearEyes, _isAchieveClearEyes, _isActiveTitileClearEyes);
    }

    public void GetHiddenAchieve()
    {
        _isAchieveHiiden = true;
        SaveAchieve(AchieveHidden, _isAchieveHiiden);
    }
    #endregion

    //#region Apple
    //readonly string AchieveApple = "AchieveApple";
    //readonly string ActiveIconApple = "ActiveIconApple";

    //bool _isAchieveApple;
    //public bool IsAchieveApple => _isAchieveApple;

    //bool _isActiveIconApple;
    //public bool IsActiveIconApple => _isActiveIconApple;


    //#endregion
}
