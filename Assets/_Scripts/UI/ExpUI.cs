using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    Slider _mySlider;
    int _playerLevel => Player.Instance.Level;
    float _currentExp => Player.Instance.Exp;
    float _maxExp;

    void Awake()
    {
        _mySlider = GetComponent<Slider>();
    }

    public void UpdateExpUI()
    {
        _maxExp = Player.Instance.NextExp[_playerLevel];
        _mySlider.value = _currentExp / _maxExp;
    }
}

