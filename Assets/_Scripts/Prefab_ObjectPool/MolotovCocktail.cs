using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class MolotovCocktail : RecycleObject
{

    public void Throw(Vector3 attackDirection)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(attackDirection, 3).OnComplete(Bomb)); ;
        sequence.Join(transform.DORotate(new Vector3(0, 0, 360 * 9), 3f, RotateMode.FastBeyond360));
    }

    void Bomb()
    {
        Flame flame = FactoryManager.Instance.GetFlame();
        flame.AttackPoint(transform.position);
        Restore();
    }

}
