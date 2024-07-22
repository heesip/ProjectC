using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveUI : Singleton<AchieveUI>
{
    [SerializeField] DonePieceUIBox _donePieceUIBox;
    [SerializeField] MadnessUIBox _madnessUIBox;
    [SerializeField] ClearEyesUIBox _clearEyesUIBox;
    [SerializeField] AppleUIBox _appleUIBox;

    [SerializeField] TitleUI _titleUI;
    [SerializeField] Button _appleButton;
    void Awake()
    {
        Load();
        ButtonSetting();
        _titleUI.transform.SetParent(FollowUI.Instance.transform);
        gameObject.SetActive(false);
    }

    void Load()
    {
        AchieveManager.Instance.Load();
        _donePieceUIBox.DonePieceUILoad();
        _madnessUIBox.MadnessUILoad();
        _clearEyesUIBox.ClearEyesUILoad();
        _appleUIBox.AppleUILoad();
        ActiveTitleLoad();
    }

    void ButtonSetting()
    {
        _appleButton.onClick.AddListener(() => AppleAchieve());
        _donePieceUIBox.DonePieceButton.onClick.AddListener(() => ToggleDonePiece());
        _madnessUIBox.MadnessButton.onClick.AddListener(() => ToggleMadness());
        _clearEyesUIBox.ClearEyesButton.onClick.AddListener(() => ToggleClearEyes());
    }

    void ToggleDonePiece()
    {
        if (!AchieveManager.Instance.IsAchieveDonePiece)
        {
            return;
        }
        AchieveManager.Instance.SaveDonePieceActive();
        _donePieceUIBox.ShowActive();
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
        _madnessUIBox.ShowActive();
        _clearEyesUIBox.ShowActive();
    }

    void AppleAchieve()
    {
        AchieveManager.Instance.GetAppleAchieve();
        _appleUIBox.AppleUILoad();
    }
}
