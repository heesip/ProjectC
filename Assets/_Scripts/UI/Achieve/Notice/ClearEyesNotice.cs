using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClearEyesNotice : NoticeSystem
{
    [SerializeField] GameObject _myPanel;
    [SerializeField] GameObject _clearEyesNotice;
    [SerializeField] GameObject _hiddenNotice;

    public override void Show()
    {
        _myPanel.SetActive(true);
        if (AchieveManager.Instance.IsAchieveHidden && AchieveManager.Instance.IsAchieveClearEyes)
        {
            _clearEyesNotice.SetActive(false);
            _hiddenNotice.SetActive(true);
        }
        else if (AchieveManager.Instance.IsAchieveClearEyes)
        {
            _clearEyesNotice.SetActive(true);
        }
        else
        {
            Hide();
        }
    }

    public override void Hide()
    {
        _myPanel.SetActive(false);
        _clearEyesNotice.SetActive(false);
        _hiddenNotice.SetActive(false);
    }
}
