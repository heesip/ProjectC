using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Vector3 _rightPosition;
    protected Vector3 _leftPosition;
    protected Quaternion _rightRotation;
    protected Quaternion _leftRotation;

    int _coolTime;
    float _damage;
    [SerializeField] protected float _speed;


    protected abstract void Initialize();

}

