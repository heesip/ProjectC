using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerIndicatorSystem
{
    [SerializeField] Transform _indicator;
    [SerializeField] Transform _socket;

    public Vector3 AttackDirection => IndicatorDirection();

    public void IndicatorMove(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            _indicator.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2(-moveDirection.x, moveDirection.y) * 180 / Mathf.PI);
        }
    }

    public void SocketOn()
    {
        _socket.gameObject.SetActive(true);
    }

    Vector3 IndicatorDirection()
    {
        Vector3 result = _socket.position - _indicator.position;
        return result;
    }
}
