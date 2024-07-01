using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    void Start()
    {
        AchieveManager.Instance.Load();
        if (!AchieveManager.Instance.IsAtropineTitle)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
    }
}
