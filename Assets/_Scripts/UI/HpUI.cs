using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : Singleton<HpUI>
{
    Slider _mySlider;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
    }

    public void UpdateHpUI(float currentHp, float maxHp)
    {
        _mySlider.value = currentHp / maxHp;
    }
}
