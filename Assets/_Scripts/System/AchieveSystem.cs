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
    readonly string MadnessTitleAchieve = "AtropineTitleAchieve";
    readonly string MadnessTitleActive = "AtropineTitleActive";

    [SerializeField] int _onePiece;
    public int OnePiece => _onePiece;
    int _donePiece = 4;
    bool _isDonePieceAchieve;
    public bool IsDonePieceAchieve => _isDonePieceAchieve;

    bool _isDonePieceActive;
    public bool IsDonePieceActive=> _isDonePieceActive;

    bool _isMadnessTitleAchieve;
    public bool IsMadnessTitleAchieve => _isMadnessTitleAchieve;

    bool _isMadnessTitleActive;
    public bool IsMadnessTitleActive => _isMadnessTitleActive;

    public void Load()
    {
        LoadPiece();
        LoadDonePieceActive();
        LoadTitleAchieve();
        LoadTitleActive();
    }

    public void Save()
    {
        SavePiece();
        SaveTitleAchieve();
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
        if (!_isDonePieceAchieve)
        {
            return;
        }
        _isDonePieceActive = !_isDonePieceActive;
        PlayerPrefs.SetInt(DonePieceActive, Convert.ToInt16(_isDonePieceActive));
    }

    void LoadDonePieceActive()
    {
        _isDonePieceActive = Convert.ToBoolean(PlayerPrefs.GetInt(DonePieceActive));
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
        _isDonePieceAchieve = Convert.ToBoolean(PlayerPrefs.GetInt(DonePieceAchieve));
    }
    #endregion

    #region Madness
    public void GetMadnessTitleAchieve()
    {
        _isMadnessTitleAchieve = true;
        SaveTitleAchieve();
    }

    public void SaveTitleActive()
    {
        if (!_isMadnessTitleAchieve)
        {
            return;
        }
        _isMadnessTitleActive = !_isMadnessTitleActive;
        PlayerPrefs.SetInt(MadnessTitleActive, Convert.ToInt16(_isMadnessTitleActive));
    }

    void LoadTitleActive()
    {
        _isMadnessTitleActive = Convert.ToBoolean(PlayerPrefs.GetInt(MadnessTitleActive));
    }

    void SaveTitleAchieve()
    {
        PlayerPrefs.SetInt(MadnessTitleAchieve, Convert.ToInt16(_isMadnessTitleAchieve));
    }

    void LoadTitleAchieve()
    {
        _isMadnessTitleAchieve = Convert.ToBoolean(PlayerPrefs.GetInt(MadnessTitleAchieve));
    }

    #endregion
}
