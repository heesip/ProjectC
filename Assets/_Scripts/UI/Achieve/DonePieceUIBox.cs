using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DonePieceUIBox
{
    readonly int _donePiece = 4;
    public Button DonePieceButton;
    [SerializeField] GameObject _donePieceUnlock;
    [SerializeField] GameObject _donePieceLock;

    [SerializeField] GameObject[] _stars;

    [SerializeField] GameObject _active;

    public void DonePieceUILoad()
    {
        if (AchieveManager.Instance.OnePiece == 0 || AchieveManager.Instance.OnePiece > _donePiece)
        {
            return;
        }
        for (int i = 0; i < AchieveManager.Instance.OnePiece; i++)
        {
            _stars[i].SetActive(true);
        }

        if (AchieveManager.Instance.OnePiece == _donePiece)
        {
            _donePieceLock.SetActive(false);
            _donePieceUnlock.SetActive(true);
        }
        ShowActive();
    }

    public void ShowActive()
    {
        _active.SetActive(AchieveManager.Instance.IsActiveDonePiece);
    }
}
