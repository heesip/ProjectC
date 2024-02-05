using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MK2 : Weapon
{
    [SerializeField] GameObject _mk2;
    SpriteRenderer _mk2Sprite;

    protected override void Initialize()
    {
        _rightPos = new Vector3(-5, 0, 0);
        _leftPos = new Vector3(5, 0, 0);
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        _mk2Sprite = _mk2.GetComponent<SpriteRenderer>();
        _mk2.transform.rotation = Quaternion.Euler(0, 0, -90);
        _mk2.transform.Translate(transform.up, Space.World);
    }

    private void Awake()
    {
        Initialize();
    }
    void Attack()
    {
        Vector3 rotVec = Vector3.back;
        transform.Rotate(rotVec * _speed);
    }

    void Mk2AttackPosition()
    {
        bool isReverse = Player.Instance.IsLeft;
        _mk2Sprite.flipY = isReverse;
        transform.localRotation = isReverse ? _leftRot : _rightRot;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
    }
    private void LateUpdate()
    {
        Mk2AttackPosition();
    }
}
