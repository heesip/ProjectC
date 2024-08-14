using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : Singleton<SettingUI>
{
    [SerializeField] Button _closeButton;
    [SerializeField] Button _joystickSet;
    [SerializeField] Button _keyboradSet;

    void Awake()
    {
        gameObject.SetActive(false);
        _closeButton.onClick.AddListener(() => CloseUI());
        _joystickSet.onClick.AddListener(() => JoyStickSet());
        _keyboradSet.onClick.AddListener(() => KeyBoradSet());
    }

    void CloseUI()
    {
        gameObject.SetActive(false);
        Player.Instance.gameObject.SetActive(true);
    }

    void JoyStickSet()
    {
        Player.Instance.JoyStickSet();
    }
    
    void KeyBoradSet()
    {
        Player.Instance.KeyBoardSet();
    }

}
