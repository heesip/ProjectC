using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : Weapon
{
    private void Awake()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _rightPos = new Vector3(-1, 3, 0);
        _leftPos = new Vector3(1, 3, 0);
        _rightRot = Quaternion.Euler(0, 0, 75);
        _leftRot = Quaternion.Euler(0, 0, -75);
    }

    private void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;

        transform.localRotation = isReverse ? _leftRot : _rightRot;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
    }
}
