using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : Singleton<SettingUI>
{
    bool _isJoyStick;
    public bool IsJoyStick => _isJoyStick;
    [SerializeField] Button _closeButton;
    [SerializeField] Button _joyStickButton;
    [SerializeField] Button _keyBoardButton;

    void Awake()
    {
        gameObject.SetActive(false);
        _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        _joyStickButton.onClick.AddListener(() => _isJoyStick = true);
        _keyBoardButton.onClick.AddListener(() => _isJoyStick = false);
    }
}
