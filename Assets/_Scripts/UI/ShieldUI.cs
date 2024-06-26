using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    Slider _mySlider;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
    }

    public void UpdateShieldUI(float currentShield, float maxShield)
    {
        _mySlider.value = currentShield / maxShield;
    }
}
