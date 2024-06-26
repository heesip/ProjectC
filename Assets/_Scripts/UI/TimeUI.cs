using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    Text _myText;

    void Awake()
    {
        _myText = GetComponent<Text>();
    }

    public void UpdateTimeUI(int minute, int second)
    {
        _myText.text = $"{minute:D2}:{second:D2}";
    }
}
