using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Joystick _joystick;
    public Joystick Joystick => _joystick;

    [SerializeField] Button _achieveSwitch;
    [SerializeField] Button _settingSwitch;
    [SerializeField] Button _hideButton;

    public void Initialize()
    {
        _achieveSwitch.onClick.AddListener(() => AchieveUION());
        _settingSwitch.onClick.AddListener(() => SettingUION());
        _hideButton.onClick.AddListener(() => AchieveUI.Instance.Tier0Achieve());
        AchieveUI.Instance.Initialize();
        NoticeUI.Instance.Initialize();
        SettingUI.Instance.Initialize();
        GameOverUI.Instance.Initialize();
        _joystick.gameObject.SetActive(false);
        UpdaateKillUI(0);
    }

    public void UpdateExpUI(float currentExp, float maxExp)
    {
        ExpUI.Instance.UpdateExpUI(currentExp, maxExp);
    }

    public void UpdateHpUI(float currentHp, float maxHp)
    {
        HpUI.Instance.UpdateHpUI(currentHp, maxHp);
    }

    public void UpdateShieldUI(float currentShield, float maxShield)
    {
        ShieldUI.Instance.UpdateShieldUI(currentShield, maxShield);
    }

    public void UpdateTimeUI(int minute, int second)
    {
        TimeUI.Instance.UpdateTimeUI(minute, second);
    }

    public void UpdaateKillUI(int kill)
    {
        KillUI.Instance.UpdateKillUI(kill);
    }

    public void GameStartUISetting()
    {
        _achieveSwitch.gameObject.SetActive(false);
        _hideButton.gameObject.SetActive(false);
        _joystick.gameObject.SetActive(true);
        Player.Instance.SocketOn();
    }

    void AchieveUION()
    {
        AudioManager.Instance.PlaySFX(SFXType.Select);
        AchieveUI.Instance.gameObject.SetActive(true);
    }

    void SettingUION()
    {
        AudioManager.Instance.PlaySFX(SFXType.Select);
        SettingUI.Instance.gameObject.SetActive(true);
        GameManager.Instance.Stop();
    }
}
