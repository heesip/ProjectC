using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveUI : MonoBehaviour
{
    [SerializeField] GameObject _atropineTitle;

    void Start()
    {
        AchieveManager.Instance.Load();
        if (!AchieveManager.Instance.IsAtropineTitleActive)
        {
            _atropineTitle.SetActive(false);
            return;
        }
        _atropineTitle.SetActive(true);
    }

    public void Toggle()
    {
        if (!AchieveManager.Instance.IsAtropineTitleAchieve)
        {
            return;
        }
        _atropineTitle.SetActive(!_atropineTitle.activeSelf);
        AchieveManager.Instance.SaveTitleAchtive();
    }

}
