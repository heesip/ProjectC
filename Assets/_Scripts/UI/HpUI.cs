using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    Slider _mySlider;
    float _currentHp => Player.Instance.Health;
    float _maxHp => Player.Instance.MaxHealth;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
    }

    public void UpdateHpUI()
    {
        _mySlider.value = _currentHp / _maxHp;
    }
}
