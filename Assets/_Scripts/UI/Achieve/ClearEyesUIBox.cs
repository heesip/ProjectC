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

    [SerializeField] GameObject _star;

    [SerializeField] GameObject _active;

    public void ClearEyesUILoad()
    {
        if (!AchieveManager.Instance.IsAchieveClearEyes)
        {
            return;
        }
        _star.SetActive(true);
        _clearEyesLock.SetActive(false);
        _clearEyesUnlock.SetActive(true);
    }

    public void ShowActive()
    {
        _active.SetActive(AchieveManager.Instance.IsActiveTitleClearEyes);
    }
}
