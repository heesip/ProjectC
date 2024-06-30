using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Joystick _joystick;
    public Joystick Joystick => _joystick;
    [SerializeField] ExpUI _expUI;
    [SerializeField] HpUI _hpUI;
    [SerializeField] ShieldUI _shieldUI;
    [SerializeField] TimeUI _timeUI;
    [SerializeField] KillUI _killUI;

    public void Initialize()
    {
        UpdaateKillUI(0);
    }

    public void UpdateExpUI(float currentExp, float maxExp)
    {
        _expUI.UpdateExpUI(currentExp, maxExp);
    }

    public void UpdateHpUI(float currentHp, float maxHp)
    {
        _hpUI.UpdateHpUI(currentHp, maxHp);
    }

    public void UpdateShieldUI(float currentShield, float maxShield)
    {
        _shieldUI.UpdateShieldUI(currentShield, maxShield);
    }

    public void UpdateTimeUI(int minute, int second)
    {
        _timeUI.UpdateTimeUI(minute, second);
    }

    public void UpdaateKillUI(int kill)
    {
        _killUI.UpdateKillUI(kill);
    }
}
