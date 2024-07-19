using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    Text _myText;
    readonly string _madness = "광기어린 아드로핀";
    readonly string _clearEyes = "맑눈광";
    Color _madnessColor = new Color32(255, 190, 0, 255);
    Color _clearEyesColor = Color.white;

    void Awake()
    {
        _myText = GetComponent<Text>();
    }

    public void ActiveTitleLoad()
    {
        if (AchieveManager.Instance.IsActiveTitleMadness)
        {
            _myText.text = _madness;
            _myText.color = _madnessColor;
        }

        else if (AchieveManager.Instance.IsActiveTitleClearEyes)
        {
            _myText.text = _clearEyes;
            _myText.color = _clearEyesColor;
        }

        else
        {
            _myText.color = Color.clear;
        }
    }
}
