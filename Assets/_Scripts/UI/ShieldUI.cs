using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    Slider _mySlider;
    float _currentShield => Player.Instance.Shield;
    float _maxShield => Player.Instance.MaxShield;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
        UpdateShieldUI();
    }

    public void UpdateShieldUI()
    {
        _mySlider.value = _currentShield / _maxShield;
    }
}
