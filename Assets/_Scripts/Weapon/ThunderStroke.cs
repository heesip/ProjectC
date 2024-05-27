using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Temp Code _ ALL 
public class ThunderStroke : MonoBehaviour
{
    float _randomX;
    float _randomY;
    Vector3 _randomVector;

    private void Start()
    {
        Test();
    }
    void Test()
    {
        for (int i = 0; i < 10; i++)
        {

        _randomX = Random.Range(-5f, 5f);
        while (_randomX >= -1.5f && _randomX <= 1.5f)
        {
            print($"E {_randomX}");
            _randomX = Random.Range(-5f, 5f);
        }
        print(_randomX);
        }

    }
}
