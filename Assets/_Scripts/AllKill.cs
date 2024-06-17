using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllKill : Bullet
{
    void Awake()
    {
        _damage = 999999;
    }
    protected new void OnEnable() { }
}
