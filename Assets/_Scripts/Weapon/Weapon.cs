using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected float _damage;
    protected float _speed;
    protected WaitForSeconds _coolTime;

    protected int _count;

    protected abstract void Initialize();
    protected abstract void FixedValue();

    private void Awake()
    {
        Initialize();
        FixedValue();
    }
}

