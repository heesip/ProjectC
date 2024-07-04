using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AchieveSystem
{
    readonly string Piece = "Piece";
    readonly string RareNinjaStar = "RareNinjaStar";
    readonly string AtropineTitleAchieve = "AtropineTitleAchieve";
    readonly string AtropineTitleActive = "AtropineTitleActive";

    [SerializeField] int _onePiece;
    int _donePiece = 4;
    bool _isRareNinjaStar;
    public bool IsRareNinjaStar => _isRareNinjaStar;

    bool _isAtropineTitleAchieve;
    public bool IsAtropineTitleAchieve => _isAtropineTitleAchieve;

    bool _isAtropineTitleActive;
    public bool IsAtropineTitleActive => _isAtropineTitleActive;

    public void Load()
    {
        LoadPiece();
        LoadTitleAchieve();
        LoadTitleActive();
    }

    public void Save()
    {
        SavePiece();
        SaveTitleAchieve();
    }
    #region NinjaStar
    public void GetNinjaStarPiece()
    {
        _onePiece++;
        _isRareNinjaStar = DonePiece();
        PlayerPrefs.SetInt(RareNinjaStar, Convert.ToInt16(_isRareNinjaStar));
        SavePiece();
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
        _isRareNinjaStar = Convert.ToBoolean(PlayerPrefs.GetInt(RareNinjaStar));
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
