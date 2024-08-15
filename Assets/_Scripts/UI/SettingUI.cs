using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : Singleton<SettingUI>
{
    [SerializeField] Button _closeButton;
    [SerializeField] Button _joystickSetLeft;
    [SerializeField] Button _joystickSetMiddle;
    [SerializeField] Button _joystickSetRight;
    [SerializeField] Button _keyboradSet;

    void Awake()
    {
        gameObject.SetActive(false);
        _closeButton.onClick.AddListener(() => CloseUI());
        _joystickSetLeft.onClick.AddListener(() => JoyStickLeftSet());
        _joystickSetMiddle.onClick.AddListener(() => JoyStickMiddleSet());
        _joystickSetRight.onClick.AddListener(() => JoyStickRightSet());
        _keyboradSet.onClick.AddListener(() => KeyBoradSet());
    }

    void CloseUI()
    {
        gameObject.SetActive(false);
        Player.Instance.gameObject.SetActive(true);
    }

    void JoyStickLeftSet()
    {
        Player.Instance.JoyStickSet();
        JoyStickUI.Instance.LeftPosition();
    }

    void JoyStickMiddleSet()
    {
        Player.Instance.JoyStickSet();
        JoyStickUI.Instance.MiddlePosition();
    }

    void JoyStickRightSet()
    {
        Player.Instance.JoyStickSet();
        JoyStickUI.Instance.RightPosition();
    }

    void KeyBoradSet()
    {
        Player.Instance.KeyBoardSet();
    }
}
