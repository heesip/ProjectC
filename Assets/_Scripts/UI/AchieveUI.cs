using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveUI : MonoBehaviour
{
    [SerializeField] GameObject _atropineTitle;
    [SerializeField] GameObject _atropine;

    [SerializeField] GameObject[] _pieces;
    [SerializeField] GameObject _donePiece;

    void Start()
    {
        AchieveManager.Instance.Load();
        DonePieceUILoad();
        AtropineUILoad();
        if (!AchieveManager.Instance.IsAtropineTitleActive)
        {
            _atropineTitle.SetActive(false);
            return;
        }
        _atropineTitle.SetActive(true);
    }

    void DonePieceUILoad()
    {
        if(AchieveManager.Instance.OnePiece == 0 || AchieveManager.Instance.OnePiece > 4)
        {
            return;
        }
        for (int i = 0; i < AchieveManager.Instance.OnePiece; i++)
        {
            _pieces[i].SetActive(true);
        }
    }

    void AtropineUILoad()
    {
        if (!AchieveManager.Instance.IsAtropineTitleAchieve)
        {
            return;
        }
        _atropine.SetActive(true);
    }

    public void DonePieceToggle()
    {
        if (!AchieveManager.Instance.IsDonePieceAchieve)
        {
            return;
        }
        AchieveManager.Instance.SaveDonePieceActive();
    }

    public void AtropineToggle()
    {
        if (!AchieveManager.Instance.IsAtropineTitleAchieve)
        {
            return;
        }
        _atropineTitle.SetActive(!_atropineTitle.activeSelf);
        AchieveManager.Instance.SaveTitleAchtive();
    }


}
