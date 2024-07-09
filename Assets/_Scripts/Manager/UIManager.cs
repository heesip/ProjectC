using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Joystick _joystick;
    public Joystick Joystick => _joystick;


    public void Initialize()
    {
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

    public void ToggleDonePiece()
    {
        AchieveUI.Instance.ToggleDonePiece();
    }

    public void ToggleAtropine()
    {
        AchieveUI.Instance.ToggleAtropine();
    }

}
