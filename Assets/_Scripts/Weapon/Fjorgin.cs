using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fjorgin : Weapon
{
    [SerializeField] GameObject _fjorgin;
    SpriteRenderer _fjorginSprite;

    //Temp Code
    [SerializeField] Vector3 _fjorginRightPos = new Vector3(3, 4.5f, 0);
    [SerializeField] Vector3 _fjorginLeftPos = new Vector3(-3, 4.5f, 0);

    private void Awake()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _rightPos = _fjorginRightPos;
        _leftPos = _fjorginLeftPos;
    }
    private void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;
        _fjorginSprite.flipX = !isReverse;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
    }
}
