using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : RecycleObject
{

    private void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    private void OnDisable()
    {
        StopAttackCo();
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        yield return null;
    }

    void StopAttackCo()
    {
        if(_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }
    
}

