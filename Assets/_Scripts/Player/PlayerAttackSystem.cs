using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttackSystem
{
    [SerializeField] Transform _indicator;
    [SerializeField] Transform _socket;
    Player _player;
    //TempCode
    [SerializeField] float _speed = 6;


    public void Initialize(Player player)
    {
        _player = player;
        _throwingNinjaStarCoHandle = player.StartCoroutine(ThrowingNinjaStarCo());
    }

    public void IndicatorMove(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            _indicator.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-moveDirection.x, moveDirection.y) * 180 / Mathf.PI);
        }
    }

    Coroutine _throwingNinjaStarCoHandle;

    IEnumerator ThrowingNinjaStarCo()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            NinjaStar ninjaStar = FactoryManager.Instance.GetNinjaStar();
            ninjaStar.AttackPoint(_indicator.position);
            ninjaStar.Throw(NextVector(), _speed);

        }
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            _player.StopCoroutine(coHandle);
        }
    }

    Vector3 NextVector()
    {
        Vector3 result = _socket.position - _indicator.position;
        return result.normalized;
    }
}
