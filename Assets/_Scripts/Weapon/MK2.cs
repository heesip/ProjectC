using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MK2 : Weapon
{
    [SerializeField] GameObject _mk2;
    SpriteRenderer _mk2Sprite;
    //Temp Code
    [SerializeField] Vector3 _mk2RightPos = new Vector3(-5, 0, 0);
    [SerializeField] Vector3 _mk2LeftPos = new Vector3(5, 0, 0);
    [SerializeField] Vector3 _mk2Size = new Vector3(2.5f, 2.5f, 2.5f);
    [SerializeField] Quaternion _mk2Rot = Quaternion.Euler(0, 0, -90);
    protected override void Initialize()
    {
        _mk2Sprite = _mk2.GetComponent<SpriteRenderer>();
        transform.localScale = _mk2Size;
        _mk2.transform.rotation = _mk2Rot;

        _rightPos = _mk2RightPos;
        _leftPos = _mk2LeftPos;
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
        transform.localPosition = isReverse ? _leftPos : _rightPos;
    }
    private void LateUpdate()
    {
        Mk2AttackPosition();
    }
}
