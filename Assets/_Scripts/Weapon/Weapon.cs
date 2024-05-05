using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Vector3 _rightPos;
    protected Vector3 _leftPos;
    protected Quaternion _rightRot;
    protected Quaternion _leftRot;

    int _coolTime;
    float _damage;
    [SerializeField] protected float _speed;


    protected abstract void Initialize();


}

