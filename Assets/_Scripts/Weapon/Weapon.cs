using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Vector3 _rightPosition;
    protected Vector3 _leftPosition;
    protected Quaternion _rightRotation;
    protected Quaternion _leftRotation;

    protected float _damage;
    protected float _speed;
    protected WaitForSeconds _coolTime;

    protected int _count;

    protected abstract void Initialize();

}

