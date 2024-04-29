using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSocketSystem
{
    [SerializeField] Transform _indicator;
    [SerializeField] Transform _socket;

    public void IndicatorMove(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            _indicator.eulerAngles = new Vector3(0,0,Mathf.Atan2(-moveDirection.x, moveDirection.y) * 180 / Mathf.PI);
        }
    }
}
