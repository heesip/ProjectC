using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : RecycleObject
{
    #region EnemyComponent
    Rigidbody2D _rigid;
    SpriteRenderer _sprite;
    Animator _anim;
    Collider2D _coll;
    [SerializeField] RuntimeAnimatorController[] _animCon;
    #endregion

    bool _isDead;
    Rigidbody2D _target;
    [SerializeField] float _speed;
    [SerializeField] float _health;
    [SerializeField] float _maxHealth;
    Vector2 _direction;
    Vector2 _nextVec;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _coll = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        LiveSet();
    }

    void FixedUpdate()
    {
        Run();
    }

    void LateUpdate()
    {
        Turn();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            return;
        }
        DeadSet();

    }

    void LiveSet()
    {
        _health = _maxHealth;
        _isDead = false;
        _coll.enabled = true;
        _rigid.simulated = true;
        _anim.SetBool("Dead", false);
        _target = Player.Instance.GetComponent<Rigidbody2D>();
    }

    void DeadSet()
    {
        _isDead = true;
        _coll.enabled = false;
        _rigid.simulated = false;
        _anim.SetBool("Dead", true);
    }


    void Run()
    {
        if (_isDead)
        {
            return;
        }
        _direction = _target.position - _rigid.position;
        _nextVec = _direction.normalized * _speed * Time.deltaTime;
        _rigid.MovePosition(_rigid.position + _nextVec);
        _rigid.velocity = Vector2.zero;

    }

    void Turn()
    {
        if (_isDead)
        {
            return;
        }
        _sprite.flipX = _target.position.x < _rigid.position.x;

    }

    void Dead()
    {
        Restore();
        ExpGem expGem = FactoryManager.Instance.GetExpGem();
        expGem.transform.position = transform.position;
    }
}
