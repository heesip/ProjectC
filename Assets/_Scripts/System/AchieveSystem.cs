using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AchieveSystem
{
    readonly string Piece = "Piece";
    readonly string DonePieceAchieve = "DonePieceAchieve";
    readonly string DonePieceActive = "DonePieceActive";
    readonly string MadnessAchieve = "MadnessAchieve";
    readonly string MadnessTitleActive = "MadnessTitleActive";

    [SerializeField] int _onePiece;
    public int OnePiece => _onePiece;
    int _donePiece = 4;

    bool _isDonePieceAchieve;
    public bool IsDonePieceAchieve => _isDonePieceAchieve;

    bool _isDonePieceActive;
    public bool IsDonePieceActive => _isDonePieceActive;

    bool _isMadnessAchieve;
    public bool IsMadnessAchieve => _isMadnessAchieve;

    bool _isMadnessTitleActive;
    public bool IsMadnessTitleActive => _isMadnessTitleActive;

    public void Load()
    {
        LoadPiece();
        LoadAchieve(DonePieceActive, out _isDonePieceActive);
        LoadAchieve(MadnessAchieve, out _isMadnessAchieve);
        LoadTitleActive(MadnessTitleActive, out _isMadnessTitleActive);
    }

    public void Save()
    {
        SavePiece();
    }

    #region DonePiece
    public void GetDonePieceAchieve()
    {
        if (DonePiece())
        {
            return;
        }

        _onePiece++;
        _isDonePieceAchieve = DonePiece();
        PlayerPrefs.SetInt(DonePieceAchieve, Convert.ToInt16(_isDonePieceAchieve));
        SavePiece();
    }

    public void SaveDonePieceActive()
    {
        _isDonePieceActive = SaveActiveToggle(DonePieceActive, _isDonePieceAchieve, _isDonePieceActive);
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
        LoadAchieve(DonePieceAchieve, out _isDonePieceAchieve);
    }
    #endregion

    #region Madness
    public void GetMadnessAchieve()
    {
        _isMadnessAchieve = true;
        SaveAchieve(MadnessAchieve, _isMadnessAchieve);
    }

    public void SaveMadnessTitleActive()
    {
        _isMadnessTitleActive = SaveActiveToggle(MadnessTitleActive, _isMadnessAchieve, _isMadnessTitleActive);
    }
    #endregion

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
}
