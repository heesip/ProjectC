using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStroke : MonoBehaviour
{
    Vector3 _randomVector;

    void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    private void OnDisable()
    {
        StopCoHandle(_attackCoHandle);
    }

    float RandomNumber(float minNumber, float maxNumber)
    {
        float randomNumber = Random.Range(minNumber, maxNumber);
        while (randomNumber >= -0.5f && randomNumber <= 0.5f)
        {
            randomNumber = Random.Range(minNumber, maxNumber);
        }
        return randomNumber;
    }

    Vector2 RandomVector(float randomX, float randomY)
    {
        Vector2 randomVector = new Vector2(randomX, randomY);
        return randomVector;
    }


    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            _randomVector = RandomVector(RandomNumber(-3, 3), RandomNumber(-6, 6));
            _randomVector += Player.Instance.transform.position;
            yield return new WaitForSeconds(1f);
            Thunder thunder = FactoryManager.Instance.GetThunder();
            thunder.AttackPoint(_randomVector);
        }
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }

}
