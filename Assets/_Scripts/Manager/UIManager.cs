using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Button _achieveSwitch;
    [SerializeField] Button _hideButton;


    public void Initialize()
    {
        _achieveSwitch.onClick.AddListener(() => AchieveUION());
        _hideButton.onClick.AddListener(() => GetTier0Achieve());


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
        Player.Instance.SocketOn();
    }

    void AchieveUION()
    {
        AchieveUI.Instance.gameObject.SetActive(true);
    }

    void GetTier0Achieve()
    {
        AchieveUI.Instance.GetTier0Achieve();
    }
}
