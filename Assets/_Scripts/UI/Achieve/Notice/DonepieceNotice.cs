using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DonepieceNotice : NoticeSystem
{
    [SerializeField] GameObject _myPanel;
    [SerializeField] GameObject _onePieceNotice;
    [SerializeField] GameObject _donePieceNotice;

    [SerializeField] GameObject[] _donePieceStars;

    public override void Show()
    {
        _myPanel.SetActive(true);
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

    public override void Hide()
    {
        _myPanel.SetActive(false);
        _onePieceNotice.SetActive(false);
        _donePieceNotice.SetActive(false);
    }

}
