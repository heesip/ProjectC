using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveUI : Singleton<AchieveUI>
{
    [SerializeField] DonePieceUIBox _donePieceUIBox;
    [SerializeField] MadnessUIBox _madnessUIBox;
    [SerializeField] ClearEyesUIBox _clearEyesUIBox;
    [SerializeField] Tier0UIBox _tier0UIBox;

    [SerializeField] TitleUI _titleUI;
    [SerializeField] Button _closeButton;
    public void Initialize()
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
        _tier0UIBox.Tier0UILoad();
        ActiveTitleLoad();
    }

    void ButtonSetting()
    {
        _donePieceUIBox.DonePieceButton.onClick.AddListener(() => ToggleDonePiece());
        _madnessUIBox.MadnessButton.onClick.AddListener(() => ToggleMadness());
        _clearEyesUIBox.ClearEyesButton.onClick.AddListener(() => ToggleClearEyes());
        _closeButton.onClick.AddListener(() => UIClose());
    }

    void ToggleDonePiece()
    {
        if (!AchieveManager.Instance.IsAchieveDonePiece)
        {
            return;
        }
        AudioManager.Instance.PlaySFX(SFXType.Select);
        AchieveManager.Instance.SaveDonePieceActive();
        _donePieceUIBox.ShowActive();
    }

    void ToggleMadness()
    {
        if (!AchieveManager.Instance.IsAchieveMadness)
        {
            return;
        }
        AudioManager.Instance.PlaySFX(SFXType.Select);
        AchieveManager.Instance.SaveMadnessTitleActive();
        ActiveTitleLoad();
    }

    void ToggleClearEyes()
    {
        if (!AchieveManager.Instance.IsAchieveClearEyes)
        {
            return;
        }
        AudioManager.Instance.PlaySFX(SFXType.Select);
        AchieveManager.Instance.SaveClearEyesTitleActive();
        ActiveTitleLoad();
    }

    void ActiveTitleLoad()
    {
        _titleUI.ActiveTitleLoad();
        _madnessUIBox.ShowActive();
        _clearEyesUIBox.ShowActive();
    }

    void UIClose()
    {
        AudioManager.Instance.PlaySFX(SFXType.Select);
        gameObject.SetActive(false);
    }

    public void Tier0Achieve()
    {
        AchieveManager.Instance.GetTier0Achieve();
        AudioManager.Instance.PlaySFX(SFXType.Select);
        _tier0UIBox.Tier0UILoad();
    }
}
