using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ClearEyesUIBox
{
    public Button ClearEyesButton;
    [SerializeField] GameObject _clearEyesUnlock;
    [SerializeField] GameObject _clearEyesLock;
    [SerializeField] GameObject _hiddenAchieve;

    [SerializeField] GameObject _star;

    [SerializeField] GameObject _active;

    public void ClearEyesUILoad()
    {
        if (!AchieveManager.Instance.IsAchieveClearEyes)
        {
            return;
        }
        else if (AchieveManager.Instance.IsAchieveHidden)
        {
            _hiddenAchieve.SetActive(true);
            _clearEyesLock.SetActive(false);
            _clearEyesUnlock.SetActive(false);
        }
        else
        {
            _clearEyesUnlock.SetActive(true);
            _hiddenAchieve.SetActive(false);
            _clearEyesLock.SetActive(false);
        }
        _star.SetActive(true);
    }

    public void ShowActive()
    {
        _active.SetActive(AchieveManager.Instance.IsActiveTitleClearEyes);
    }
}
