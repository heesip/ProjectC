using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MadnessUIBox
{
    public Button MadnessButton;
    [SerializeField] GameObject _madnessUnlock;
    [SerializeField] GameObject _madnessLock;

    [SerializeField] GameObject _star;

    [SerializeField] GameObject _active;

    public void MadnessUILoad()
    {
        if (!AchieveManager.Instance.IsAchieveMadness)
        {
            return;
        }
        _star.SetActive(true);
        _madnessLock.SetActive(false);
        _madnessUnlock.SetActive(true);
    }

    public void ShowActive()
    {
        _active.SetActive(AchieveManager.Instance.IsActiveTitleMadness);
    }
}
