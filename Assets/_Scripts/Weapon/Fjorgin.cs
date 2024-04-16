using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fjorgin : Weapon
{
    [SerializeField] GameObject _fjorgin;
    SpriteRenderer _fjorginSprite;
    Animator _anim;
    [SerializeField] bool _isReverse;
    //Temp Code
    [SerializeField] Vector3 _fjorginRightPos = new Vector3(0, 2.5f, 0);
    [SerializeField] Vector3 _fjorginLeftPos = new Vector3(0, 2.5f, 0);

    WaitForSeconds _coolTime = new WaitForSeconds(3);



    protected override void Initialize()
    {
        _anim = GetComponent<Animator>();

        _fjorginSprite = _fjorgin.GetComponent<SpriteRenderer>();
        _fjorgin.transform.Translate(transform.up/*, Space.World*/);
        _rightPos = _fjorginRightPos;
        _leftPos = _fjorginLeftPos;
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    private void OnDisable()
    {
        StopAttackCo();
    }



    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {

        while (true)
        {
            yield return null;
            AttackPosition();
            switch (_isReverse)
            {
                case false:
                    _anim.SetTrigger("isRight");
                    break;
                case true:
                    _anim.SetTrigger("isLeft");
                    break;
            }
            yield return _coolTime;

        }


    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }



    void AttackPosition()
    {
        _isReverse = Player.Instance.IsLeft;
        _fjorginSprite.flipX = !_isReverse;
        transform.localPosition = _isReverse ? _leftPos : _rightPos;
    }
}
