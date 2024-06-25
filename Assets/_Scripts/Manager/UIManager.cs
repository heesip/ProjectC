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


    public void UpdateExpUI()
    {
        _expUI.UpdateExpUI();
    }

    public void UpdateHpUI()
    {
        _hpUI.UpdateHpUI();
    }

    public void UpdateShieldUI()
    {
        _shieldUI.UpdateShieldUI();
    }
}
