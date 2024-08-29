using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : Singleton<SettingUI>
{
    bool _isKeyboard;
    public bool IsKeyboard => _isKeyboard;
    [SerializeField] Button _closeButton;
    [SerializeField] Button _joyStickButton;
    [SerializeField] Button _keyBoardButton;
    [SerializeField] Button _restartButton;

    readonly string KeySetting = "KeySetting";

    public void Initialize()
    {
        gameObject.SetActive(false);
        LoadKeySetting();
        _closeButton.onClick.AddListener(() => UIClose());
        _joyStickButton.onClick.AddListener(() => JoyStickSet());
        _keyBoardButton.onClick.AddListener(() => KeyBoardSet());
        _restartButton.onClick.AddListener(() => ReStart());
        _restartButton.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        _restartButton.gameObject.SetActive(true);
    }

    void UIClose()
    {
        AudioManager.Instance.PlaySFX(SFXType.Select);
        gameObject.SetActive(false);
        GameManager.Instance.Resume();
    }

    void SaveKeySetting()
    {
        PlayerPrefs.SetInt(KeySetting, Convert.ToInt16(_isKeyboard));
    }

    void LoadKeySetting()
    {
        _isKeyboard = Convert.ToBoolean(PlayerPrefs.GetInt(KeySetting));
    }

    void JoyStickSet()
    {
        AudioManager.Instance.PlaySFX(SFXType.Select);
        _isKeyboard = true;
        SaveKeySetting();
    }

    void KeyBoardSet()
    {
        AudioManager.Instance.PlaySFX(SFXType.Select);
        _isKeyboard = false;
        SaveKeySetting();
    }
    void ReStart()
    {
        UIClose();
        GameOverUI.Instance.GameOver();
    }
}
