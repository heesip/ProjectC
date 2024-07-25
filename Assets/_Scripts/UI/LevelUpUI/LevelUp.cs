using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : Singleton<LevelUp>
{
    [SerializeField] SelectBox[] _selectBoxs;

    private void Awake()
    {
        _selectBoxs = GetComponentsInChildren<SelectBox>();
    }

}
