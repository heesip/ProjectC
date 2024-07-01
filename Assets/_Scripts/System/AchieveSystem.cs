using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AchieveSystem
{
    readonly string Piece = "Piece";
    readonly string RareNinjaStar = "RareNinjaStar";
    readonly string AtropineTitle = "AtropineTitle";

    [SerializeField] int _onePiece;
    int _donePiece = 4;
    bool _isRareNinjaStar;
    public bool IsRareNinjaStar => _isRareNinjaStar;

    bool _isAtropineTitle;
    public bool IsAtropineTitle => _isAtropineTitle;

    public void Load()
    {
        LoadPiece();
        LoadTitle();
    }

    public void Save()
    {
        SavePiece();
    }

    public void GetNinjaStarPiece()
    {
        _onePiece++;
        _isRareNinjaStar = DonePiece();
        PlayerPrefs.SetInt(RareNinjaStar, Convert.ToInt16(_isRareNinjaStar));
        SavePiece();
    }

    public void GetAtropineTitle()
    {
        _isAtropineTitle = true;
        SaveTitle();
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

    void SaveTitle()
    {
        PlayerPrefs.SetInt(AtropineTitle, Convert.ToInt16(_isAtropineTitle));
    }

    void LoadTitle()
    {
        _isAtropineTitle = Convert.ToBoolean(PlayerPrefs.GetInt(AtropineTitle));
    }

}
