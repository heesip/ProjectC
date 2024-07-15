using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveUI : Singleton<AchieveUI>
{
    [SerializeField] DonePieceUIBox _donePieceUIBox;
    [SerializeField] MadnessUIBox _madnessUIBox;

    [SerializeField] GameObject _madnessTitle;

    void Awake()
    {
        AchieveManager.Instance.Load();
        _donePieceUIBox.DonePieceUILoad();
        _madnessUIBox.MadnessUILoad();
        _donePieceUIBox.DonePieceButton.onClick.AddListener(() => ToggleDonePiece());
        _madnessUIBox.MadnessButton.onClick.AddListener(() => ToggleMadness());
        MadnessTitleLoad();
    }

    void MadnessTitleLoad()
    {
        if (!AchieveManager.Instance.IsMadnessTitleActive)
        {
            _madnessTitle.SetActive(false);
            return;
        }
        _madnessTitle.SetActive(true);
        TitleUIMove();
    }

    void ToggleDonePiece()
    {
        if (!AchieveManager.Instance.IsDonePieceAchieve)
        {
            return;
        }
        AchieveManager.Instance.SaveDonePieceActive();
    }

    void ToggleMadness()
    {
        if (!AchieveManager.Instance.IsMadnessTitleAchieve)
        {
            return;
        }

        AchieveManager.Instance.SaveTitleAchtive();
        _madnessTitle.SetActive(AchieveManager.Instance.IsMadnessTitleActive);
        TitleUIMove();
    }

    void TitleUIMove()
    {
        if (AchieveManager.Instance.IsMadnessTitleActive)
        {
            _madnessTitle.transform.SetParent(FollowUI.Instance.transform);
        }
        else
        {
            _madnessTitle.transform.SetParent(transform);
        }
    }

}
