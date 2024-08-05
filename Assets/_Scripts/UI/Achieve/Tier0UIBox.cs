using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tier0UIBox
{
    [SerializeField] GameObject _tier0Unlock;
    [SerializeField] GameObject _tier0Lock;

    [SerializeField] GameObject _star;

    public void Tier0UILoad()
    {
        if (!AchieveManager.Instance.IsAchieveApple)
        {
            return;
        }
        _star.SetActive(true);
        _tier0Lock.SetActive(false);
        _tier0Unlock.SetActive(true);
    }
}
