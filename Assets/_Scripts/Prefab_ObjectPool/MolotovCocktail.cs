using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class MolotovCocktail : RecycleObject
{
    float _flameDamage;
    float _flameDuration;
    WaitForSeconds _flameCoolTime;
    float _molotovCocktailDuration;
    Vector3 _molotovCocktailRotate;

    public void Initialize(float molotovCocktailDuration,
                           Vector3 molotovCocktailRotate,
                           float flameDamage,
                           float flameDuration,
                           WaitForSeconds flameCoolTime)
    {
        _molotovCocktailDuration = molotovCocktailDuration;
        _molotovCocktailRotate = molotovCocktailRotate;

        _flameCoolTime = flameCoolTime;
        _flameDamage = flameDamage;
        _flameDuration = flameDuration;
    }

    public void Throw(Vector3 attackDirection)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(attackDirection, _molotovCocktailDuration).OnComplete(Bomb)); ;
        sequence.Join(transform.DORotate(_molotovCocktailRotate, _molotovCocktailDuration, RotateMode.FastBeyond360));
    }

    void Bomb()
    {
        Flame flame = FactoryManager.Instance.GetFlame();
        flame.Initialize(_flameDamage, _flameDuration);
        flame.AttackPoint(transform.position);
        Restore();
    }


}
