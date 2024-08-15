using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickUI : Singleton<JoyStickUI>
{
    [SerializeField] RectTransform _joyStick;
    readonly Vector3 _leftPosition = new Vector3(-30, 0, 0);
    readonly Vector3 _rightPosition = new Vector3(30, 0, 0);

    public void LeftPosition()
    {
        _joyStick.anchoredPosition = _leftPosition;
    }

    public void MiddlePosition()
    {
        _joyStick.anchoredPosition = Vector3.zero;
    }

    public void RightPosition()
    {
        _joyStick.anchoredPosition = _rightPosition;
    }
}
