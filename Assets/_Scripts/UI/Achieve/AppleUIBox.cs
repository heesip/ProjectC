using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AppleUIBox
{
    public Button AppleButton;
    [SerializeField] GameObject _appleUnlock;
    [SerializeField] GameObject _appleLock;

    [SerializeField] GameObject _star;

    public void AppleUILoad()
    {

        _star.SetActive(true);
        _appleLock.SetActive(false);
        _appleUnlock.SetActive(true);
    }
}
