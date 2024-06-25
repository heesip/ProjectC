using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    Slider _mySlider;
    float _currentExp => Player.Instance.Exp;
    float _maxExp;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
    }

    public void UpdateExpUI()
    {
        int nextExp = Mathf.Min(Player.Instance.Level, Player.Instance.NextExp.Length - 1);
        _maxExp = Player.Instance.NextExp[nextExp];
        _mySlider.value = _currentExp / _maxExp;
    }
}

