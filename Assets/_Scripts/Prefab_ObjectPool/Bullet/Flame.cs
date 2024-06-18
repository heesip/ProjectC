using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : Bullet
{
    protected override void OnStart()
    {
        _isProjectile = false;
    }
    public void Initialize(float damage, float duration)
    {
        _damage = damage;
        _duration = duration;
    }

}
