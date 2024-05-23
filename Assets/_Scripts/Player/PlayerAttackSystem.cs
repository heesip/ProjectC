using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem
{
    Player _player;


    public void Initialize(Player player)
    {
        _player = player;
        _throwingNinjaStarCoHandle = player.StartCoroutine(ThrowingNinjaStarCo());
    }
    Coroutine _throwingNinjaStarCoHandle;

    IEnumerator ThrowingNinjaStarCo()
    {
        
        while (true)
        {
            NinjaStar ninjaStar = FactoryManager.Instance.GetNinjaStar();
            yield return new WaitForSeconds(5);
            ninjaStar.transform.position = Player.Instance.transform.position;

        }
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            _player.StopCoroutine(coHandle);
        }
    }

}
