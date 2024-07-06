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
    readonly string AtropineTitleAchieve = "AtropineTitleAchieve";
    readonly string AtropineTitleActive = "AtropineTitleActive";

    [SerializeField] int _onePiece;
    public int OnePiece => _onePiece;
    int _donePiece = 4;
    bool _isDonePieceAchieve;
    public bool IsDonePieceAchieve => _isDonePieceAchieve;

    bool _isDonePieceActive;
    public bool IsDonePieceActive=> _isDonePieceActive;

    bool _isAtropineTitleAchieve;
    public bool IsAtropineTitleAchieve => _isAtropineTitleAchieve;

    bool _isAtropineTitleActive;
    public bool IsAtropineTitleActive => _isAtropineTitleActive;

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
    #region NinjaStar
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

    #region Atropine
    public void GetAtropineTitleAchieve()
    {
        _isAtropineTitleAchieve = true;
        SaveTitleAchieve();
    }

    public void SaveTitleActive()
    {
        if (!_isAtropineTitleAchieve)
        {
            return;
        }
        _isAtropineTitleActive = !_isAtropineTitleActive;
        PlayerPrefs.SetInt(AtropineTitleActive, Convert.ToInt16(_isAtropineTitleActive));
    }

    void LoadTitleActive()
    {
        _isAtropineTitleActive = Convert.ToBoolean(PlayerPrefs.GetInt(AtropineTitleActive));
    }

    void SaveTitleAchieve()
    {
        PlayerPrefs.SetInt(AtropineTitleAchieve, Convert.ToInt16(_isAtropineTitleAchieve));
    }

    void LoadTitleAchieve()
    {
        _isAtropineTitleAchieve = Convert.ToBoolean(PlayerPrefs.GetInt(AtropineTitleAchieve));
    }

    #endregion
}
