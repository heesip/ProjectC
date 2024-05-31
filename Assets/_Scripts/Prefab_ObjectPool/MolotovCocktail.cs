using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class MolotovCocktail : RecycleObject
{

    private void OnDisable()
    {
        StopCoHandle();
    }
    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        yield return new WaitForSeconds(1.5f);
        Flame flame = FactoryManager.Instance.GetFlame();
        flame.AttackPoint(transform.position);
        Restore();
    }

    public void Throw(Vector3 attackDirection)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(attackDirection, 3).OnComplete(Bomb)); ;
        // sequence.Join(transform.DORotate(new Vector3(0, 0, 360 * 7), 1f, RotateMode.FastBeyond360).SetEase(Ease.OutSine));

    }


    void Bomb()
    {
        //_attackCoHandle = StartCoroutine(AttackCo());
        Flame flame = FactoryManager.Instance.GetFlame();
        flame.AttackPoint(transform.position);
        Restore();
    }

    void StopCoHandle()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }
}
