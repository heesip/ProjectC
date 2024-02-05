using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fjorgin : Weapon
{
    [SerializeField] GameObject _fjorgin;
    SpriteRenderer _fjorginSprite;
    private void Awake()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _rightPos = new Vector3(3, 4.5f, 0);
        _leftPos = new Vector3(-3, 4.5f, 0);
    }
    private void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;
        _fjorginSprite.flipX = !isReverse;
        transform.localRotation = isReverse ? _leftRot : _rightRot;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
    }
}
