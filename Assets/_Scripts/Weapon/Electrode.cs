using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrode : MonoBehaviour
{
    Collider2D _collider;
    WaitForSeconds _attackInterval = new WaitForSeconds(.5f);
    WaitForSeconds _coolTime = new WaitForSeconds(5);
    int _count = 5;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

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
        while (true)
        {

            for (int i = 0; i < _count; i++)
            {
                _collider.enabled = true;
                yield return _attackInterval;
                _collider.enabled = false;
                yield return _attackInterval;
            }
           yield return _coolTime;
        }
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }

}
