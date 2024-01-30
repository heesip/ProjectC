using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    private void Awake()
    {
        GameResourcesManager.Instance.Initialize();
        FactoryManager.Instance.Initialize();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.L))
        {
            return;
        }
    }

}
