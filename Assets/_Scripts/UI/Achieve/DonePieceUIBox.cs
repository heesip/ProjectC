using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DonePieceUIBox
{
    public Button DonePieceButton;
    [SerializeField] GameObject _donePieceUnlock;
    [SerializeField] GameObject _donePieceLock;

    [SerializeField] GameObject[] _stars;

    public void DonePieceUILoad()
    {
        if (AchieveManager.Instance.OnePiece == 0 || AchieveManager.Instance.OnePiece > 4)
        {
            return;
        }
        for (int i = 0; i < AchieveManager.Instance.OnePiece; i++)
        {
            _stars[i].SetActive(true);
        }

        if (AchieveManager.Instance.OnePiece == 4)
        {
            _donePieceLock.SetActive(false);
            _donePieceUnlock.SetActive(true);
        }
    }

}
