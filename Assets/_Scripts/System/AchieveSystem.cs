using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AchieveSystem
{
    [SerializeField] int _onePiece;
    int _donePiece = 4;
    readonly string Piece = "Piece";
    readonly string RareNinjaStar = "RareNinjaStar";
    bool _isRareNinjaStar;
    public bool IsRareNinjaStar => _isRareNinjaStar;

    public void Load()
    {
        _onePiece = PlayerPrefs.GetInt(Piece);
        _isRareNinjaStar = Convert.ToBoolean(PlayerPrefs.GetInt(RareNinjaStar));
    }

    public void Save()
    {
        SavePiece();
    }

    public void GetNinjaStarPiece()
    {
        _onePiece++;
        if (_onePiece == _donePiece)
        {
            _isRareNinjaStar = true;
            PlayerPrefs.SetInt(RareNinjaStar, Convert.ToInt16(_isRareNinjaStar));
        }
        SavePiece();
    }

    void SavePiece()
    {
        PlayerPrefs.SetInt(Piece, _onePiece);
    }

}
