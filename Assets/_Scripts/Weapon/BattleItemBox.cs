using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BattleItemBox : MonoBehaviour
{
    Vector3 _attackDirection => Player.Instance.AttackDirection;
    //TempCode
    [SerializeField] float _speed = 6;
    [SerializeField] bool isNinjaStar;
    [SerializeField] bool isMolotovCocktail;


    private void OnEnable()
    {
        if (isNinjaStar)
        {
            _throwingNinjaStarCoHandle = StartCoroutine(ThrowingNinjaStarCo());
        }
        if (isMolotovCocktail)
        {
            _throwMolotovCocktailCoHandle = StartCoroutine(ThrowingMolotovCocktail());
        }
    }

    private void OnDisable()
    {
        StopCoHandle(_throwingNinjaStarCoHandle, _throwMolotovCocktailCoHandle);
    }

    Coroutine _throwingNinjaStarCoHandle;

    IEnumerator ThrowingNinjaStarCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            NinjaStar ninjaStar = FactoryManager.Instance.GetNinjaStar();
            ninjaStar.AttackPoint(transform.position);
            ninjaStar.Throw(_attackDirection, _speed);
        }
    }

    Coroutine _throwMolotovCocktailCoHandle;

    IEnumerator ThrowingMolotovCocktail()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            MolotovCocktail molotovCocktail = FactoryManager.Instance.GetMolotovCocktail();
            molotovCocktail.transform.position = transform.position;
            molotovCocktail.Throw(AttackDirection());
        }
    }

    Vector3 AttackDirection()
    {
        Vector3 result = transform.position + (_attackDirection * 2.5f);
        return result;
    }


    void StopCoHandle(Coroutine coHandle1, Coroutine coHandle2)
    {
        if (coHandle1 != null)
        {
            StopCoroutine(coHandle1);
        }
        if (coHandle2 != null)
        {
            StopCoroutine(coHandle2);
        }
    }

}
