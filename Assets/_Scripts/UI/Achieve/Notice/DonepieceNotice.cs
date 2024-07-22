using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DonepieceNotice
{
    [SerializeField] GameObject _myNotice;
    [SerializeField] GameObject _onePieceNotice;
    [SerializeField] GameObject _donePieceNotice;

    [SerializeField] GameObject[] _donePieceStars;

    public void GetPiece()
    {
        _myNotice.SetActive(true);
        _onePieceNotice.SetActive(true);
        for (int i = 0; i < AchieveManager.Instance.OnePiece; i++)
        {
            _donePieceStars[i].SetActive(true);
            if(i == 3)
            {
                _onePieceNotice.SetActive(false);
                _donePieceNotice.SetActive(true);
            }
        }
    }

    public void HideNotice()
    {
        _myNotice.SetActive(false);
    }

}
