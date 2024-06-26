using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected readonly int _maxLevel = 2;
    protected int _weaponLevel;

    protected float _damage;
    protected float _speed;
    protected WaitForSeconds _coolTime;

    protected int _count;

    protected abstract void Initialize();
    protected abstract void FixedValue();
    public abstract void UseWeapon();

    private void Awake()
    {
        Initialize();
        FixedValue();
    }
}

