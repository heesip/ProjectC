using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveUI : Singleton<AchieveUI>
{
    [SerializeField] DonePieceUIBox _donePieceUIBox;
    [SerializeField] MadnessUIBox _madnessUIBox;
    [SerializeField] ClearEyesUIBox _clearEyesUIBox;

    [SerializeField] TitleUI _titleUI;

    void Awake()
    {
        AchieveManager.Instance.Load();
        _donePieceUIBox.DonePieceUILoad();
        _madnessUIBox.MadnessUILoad();
        _clearEyesUIBox.ClearEyesUILoad();
        ActiveTitleLoad();
        _donePieceUIBox.DonePieceButton.onClick.AddListener(() => ToggleDonePiece());
        _madnessUIBox.MadnessButton.onClick.AddListener(() => ToggleMadness());
        _clearEyesUIBox.ClearEyesButton.onClick.AddListener(() => ToggleClearEyes());

        _titleUI.transform.SetParent(FollowUI.Instance.transform);
        gameObject.SetActive(false);
    }

    void ToggleDonePiece()
    {
        if (!AchieveManager.Instance.IsAchieveDonePiece)
        {
            return;
        }
        AchieveManager.Instance.SaveDonePieceActive();
    }

    void ToggleMadness()
    {
        if (!AchieveManager.Instance.IsAchieveMadness)
        {
            return;
        }

        AchieveManager.Instance.SaveMadnessTitleActive();
        ActiveTitleLoad();
    }

    void ToggleClearEyes()
    {
        if (!AchieveManager.Instance.IsAchieveClearEyes)
        {
            return;
        }

        AchieveManager.Instance.SaveClearEyesTitleActive();
        ActiveTitleLoad();
    }

    void ActiveTitleLoad()
    {
        _titleUI.ActiveTitleLoad();
    }

}
