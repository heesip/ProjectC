using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : Bullet
{
    protected override void OnStart()
    {
        //TempCode
        _duration = 5;
        _isProjectile = false;
    }

}
