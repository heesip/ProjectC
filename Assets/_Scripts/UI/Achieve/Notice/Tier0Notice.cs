using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tier0Notice : NoticeSystem
{
    [SerializeField] GameObject _myPanel;

    public override void Show()
    {
        _myPanel.SetActive(true);
    }

    public override void Hide()
    {
        _myPanel.SetActive(false);
    }
}
