using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Joystick _joystick;
    public Joystick Joystick => _joystick;

}
