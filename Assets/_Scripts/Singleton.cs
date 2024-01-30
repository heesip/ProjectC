﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                {
                    Debug.LogError($"{typeof(T)} 싱글턴 클래스 없음");
                }
            }

            return _instance;
        }

    }

    private void OnDestroy()
    {
        _instance = null;
    }
}