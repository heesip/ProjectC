using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BattleItemBox : MonoBehaviour
{
    [SerializeField] BattleItemBoxDataSO _battleItemBoxDataSO;
    Vector3 _attackDirection => Player.Instance.AttackDirection;
    Vector3 _projectileRotate;

    float _ninjaStarDamage;
    float _ninjaStarSpeed;
    float _ninjaStarDurtaion;
    WaitForSeconds _ninjaStarCoolTime;

    float _molotovCocktailRange;
    float _molotovCocktailDuration;
    WaitForSeconds _molotovCocktailCoolTime;
    WaitForSeconds _flameCoolTime;
    float _flameDamage;
    float _flameDuration;

    void Awake()
    {
        _battleItemBoxDataSO = GameDataManager.Instance.GetBattleItemBoxDataSO();
    }

    void FixedValue()
    {
        _projectileRotate = _battleItemBoxDataSO.ProjectileRotate;
        _ninjaStarDurtaion = _battleItemBoxDataSO.NinjaStarDuration;
        _ninjaStarSpeed = _battleItemBoxDataSO.NinjaStarSpeed;

        _molotovCocktailRange = _battleItemBoxDataSO.MolotovCocktailRange;
        _molotovCocktailDuration = _battleItemBoxDataSO.MolotovCocktailDuration;
        _flameCoolTime = _battleItemBoxDataSO.FlameCoolTime;
        _flameDuration = _battleItemBoxDataSO.FlameDuration;
    }

    void LevelValue(int level)
    {
        _ninjaStarDamage = _battleItemBoxDataSO.NinjaStarDamages[level];
        _ninjaStarCoolTime = _battleItemBoxDataSO.NinjaStarCoolTimes[level];

        _molotovCocktailCoolTime = _battleItemBoxDataSO.MolotovCocktailCoolTimes[level];
        _flameDamage = _battleItemBoxDataSO.FlameDamages[level];
    }

    void OnEnable()
    {
        FixedValue();
        LevelValue(1);
        _throwMolotovCocktailCoHandle = StartCoroutine(ThrowingMolotovCocktail());
        _throwingNinjaStarCoHandle = StartCoroutine(ThrowingNinjaStarCo());
    }

    void OnDisable()
    {
        StopCoHandle(_throwingNinjaStarCoHandle);
        StopCoHandle(_throwMolotovCocktailCoHandle);
    }

    Coroutine _throwingNinjaStarCoHandle;

    void ThrowingNinjaStar(float ninjaStarDamage)
    {
        NinjaStar ninjaStar = FactoryManager.Instance.GetNinjaStar();
        ninjaStar.Initiazlie(ninjaStarDamage, _ninjaStarSpeed, _ninjaStarDurtaion, _projectileRotate);
        ninjaStar.AttackPoint(transform.position);
        ninjaStar.Throw(_attackDirection);
    }

    IEnumerator ThrowingNinjaStarCo()
    {
        while (true)
        {
            if (Player.Instance.IsAtropine)
            {
                yield return _battleItemBoxDataSO.AtropineNinjaStarCoolTime;
                ThrowingNinjaStar(_battleItemBoxDataSO.AtroPineNinjaStarDamage);
            }
            else
            {
                yield return _ninjaStarCoolTime;
                ThrowingNinjaStar(_ninjaStarDamage);
            }
        }
    }

    Coroutine _throwMolotovCocktailCoHandle;

    IEnumerator ThrowingMolotovCocktail()
    {
        while (true)
        {
            yield return _molotovCocktailCoolTime;
            MolotovCocktail molotovCocktail = FactoryManager.Instance.GetMolotovCocktail();
            molotovCocktail.Initialize(_molotovCocktailDuration, _projectileRotate,
                                       _flameDamage, _flameDuration, _flameCoolTime);
            molotovCocktail.transform.position = transform.position;
            molotovCocktail.Throw(AttackDirection());
        }
    }

    Vector3 AttackDirection()
    {
        Vector3 result = transform.position + (_attackDirection * _molotovCocktailRange);
        return result;
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }
    
}
