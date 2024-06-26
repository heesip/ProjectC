using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    Slider _mySlider;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
    }

    public void UpdateExpUI(float currentExp, float maxExp)
    {
        _mySlider.value = currentExp / maxExp;
    }
}

