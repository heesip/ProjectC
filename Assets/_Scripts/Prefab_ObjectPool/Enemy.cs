using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : RecycleObject
{
    #region EnemyComponent
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    Collider2D _collider;
    #endregion

    bool _isDead;
    Rigidbody2D _target;
    [SerializeField] float _speed;
    [SerializeField] float _health;
    [SerializeField] float _maxHealth;
    Vector2 _direction;
    Vector2 _nextVector;

    RuntimeAnimatorController RandomAnimation()
    {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                return GameResourcesManager.Instance.GetEnemyA_Animator();
            case 2:
                return GameResourcesManager.Instance.GetEnemyB_Animator();
            case 3:
                return GameResourcesManager.Instance.GetEnemyC_Animator();
            default:
                return GameResourcesManager.Instance.GetEnemyA_Animator();
        }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        LiveSet();
        _animator.runtimeAnimatorController = RandomAnimation();
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
        if (!collision.CompareTag(AllStrings.Bullet))
        {
            return;
        }

        if (_health <= 0)
        {
            DeadSet();
        }

    }

    public void OnDamage(GameObject bullet, float damage)
    {
        if (!bullet.CompareTag(AllStrings.Bullet))
        {
            return;
        }
        _health -= damage;
        print($"hit{damage}");
    }

    void LiveSet()
    {
        _health = _maxHealth;
        _isDead = false;
        _collider.enabled = true;
        _rigidbody.simulated = true;
        _animator.SetBool(AllStrings.Dead, false);
        _target = Player.Instance.GetComponent<Rigidbody2D>();
    }

    void DeadSet()
    {
        _isDead = true;
        _collider.enabled = false;
        _rigidbody.simulated = false;
        _animator.SetBool(AllStrings.Dead, true);
    }


    void Run()
    {
        if (_isDead)
        {
            return;
        }
        _direction = _target.position - _rigidbody.position;
        _nextVector = _direction.normalized * _speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + _nextVector);
        _rigidbody.velocity = Vector2.zero;

    }

    void Turn()
    {
        if (_isDead)
        {
            return;
        }
        _spriteRenderer.flipX = _target.position.x < _rigidbody.position.x;
    }

    void Dead()
    {
        Restore();
        ExpGem expGem = FactoryManager.Instance.GetExpGem();
        expGem.transform.position = transform.position;
    }
}
