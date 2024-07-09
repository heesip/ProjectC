using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveUI : Singleton<AchieveUI>
{
    [SerializeField] GameObject[] _pieces;

    [SerializeField] GameObject _atropineTitle;
    [SerializeField] GameObject _atropine;

    readonly bool isLock = true;
    [Header("DonePiece_LockUnlock")]
    [SerializeField] GameObject _donePieceLock;
    [SerializeField] GameObject _donePieceUnlock;
    [Header("Atropine_LockUnlock")]
    [SerializeField] GameObject _atropineLock;
    [SerializeField] GameObject _atropineUnlock;


    void Awake()
    {
        AchieveInitalize();
        AchieveManager.Instance.Load();
        DonePieceUILoad();
        AtropineUILoad();
        AtropineTitleLoad();
    }

    void DonePieceUILoad()
    {
        if (AchieveManager.Instance.OnePiece == 0 || AchieveManager.Instance.OnePiece > 4)
        {
            return;
        }
        for (int i = 0; i < AchieveManager.Instance.OnePiece; i++)
        {
            _pieces[i].SetActive(true);
        }

        if (AchieveManager.Instance.OnePiece == 4)
        {
            AchieveSet(_donePieceLock, _donePieceUnlock, !isLock);
        }

    }

    void AtropineUILoad()
    {
        if (!AchieveManager.Instance.IsAtropineTitleAchieve)
        {
            return;
        }
        _atropine.SetActive(true);
        AchieveSet(_atropineLock, _atropineUnlock, !isLock);

    }

    void AtropineTitleLoad()
    {
        if (!AchieveManager.Instance.IsAtropineTitleActive)
        {
            _atropineTitle.SetActive(false);
            return;
        }
        _atropineTitle.SetActive(true);
    }

    void AchieveInitalize()
    {
        AchieveSet(_donePieceLock, _donePieceUnlock, isLock);
        AchieveSet(_atropineLock, _atropineUnlock, isLock);
    }

    void AchieveSet(GameObject achieveLock, GameObject achieveUnlock, bool isLock)
    {
        achieveLock.SetActive(isLock);
        achieveUnlock.SetActive(!isLock);
    }

    public void ToggleDonePiece()
    {
        if (!AchieveManager.Instance.IsDonePieceAchieve)
        {
            return;
        }
        AchieveManager.Instance.SaveDonePieceActive();
    }

    public void ToggleAtropine()
    {
        if (!AchieveManager.Instance.IsAtropineTitleAchieve)
        {
            return;
        }
        _atropineTitle.SetActive(!_atropineTitle.activeSelf);
        AchieveManager.Instance.SaveTitleAchtive();
    }


}
