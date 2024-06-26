using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStroke : Weapon
{
    [SerializeField] ThunderStrokeDataSO _thunderStrokeDataSO;

    Vector3 _randomVector;
    float _xMinValue;
    float _xMaxValue;
    float _yMinValue;
    float _yMaxValue;
    float _exceptionMinValue;
    float _exceptionMaxValue;
    WaitForSeconds _thunderStrokeCoolTime;


    protected override void Initialize()
    {
        _thunderStrokeDataSO = GameDataManager.Instance.GetThunderStrokeDataSO();
    }

    protected override void FixedValue()
    {
        _xMinValue= _thunderStrokeDataSO.X_MinValue;
        _xMaxValue = _thunderStrokeDataSO.X_MaxValue;
        _yMinValue = _thunderStrokeDataSO.Y_MinValue;
        _yMaxValue= _thunderStrokeDataSO.Y_MaxValue;
        _exceptionMinValue = _thunderStrokeDataSO.ExceptionMinValue;
        _exceptionMaxValue = _thunderStrokeDataSO.ExceptionMaxValue;
    }

    void LevelValue(int level)
    {
        _thunderStrokeCoolTime = _thunderStrokeDataSO.ThunderStrokeCoolTimes[level];
    }

    void OnEnable()
    {
        LevelValue(0);
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    void OnDisable()
    {
        StopCoHandle(_attackCoHandle);
    }

    float RandomNumber(float minNumber, float maxNumber)
    {
        float randomNumber = Random.Range(minNumber, maxNumber);
        while (randomNumber >= _exceptionMinValue && randomNumber <= _exceptionMaxValue)
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
            _randomVector = RandomVector(RandomNumber(_xMinValue, _xMaxValue), RandomNumber(_yMinValue, _yMaxValue));
            _randomVector += Player.Instance.transform.position;
            yield return _thunderStrokeCoolTime;
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
