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
    EnemyDataSO _enemyDataSO;
    bool _isDead;
    Rigidbody2D _target;
    [SerializeField] float _speed;
    [SerializeField] float _health;
    [SerializeField] float _maxHealth;

    RuntimeAnimatorController RandomAnimation()
    {
        int randomNumber = Random.Range(_enemyDataSO.MinNumber, _enemyDataSO.MaxNumber);
        return _enemyDataSO.EnemyAnimators[randomNumber];
    }

    void Awake()
    {
        _enemyDataSO = GameDataManager.Instance.GetEnemyDataSO();
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
        _animator.SetTrigger(AllStrings.Hit);
        StopCoHandle(_knockBackCoHandle);
        _knockBackCoHandle = StartCoroutine(KnockBackCo());
    }

    void LiveSet()
    {
        _isDead = false;
        _collider.enabled = true;
        _rigidbody.simulated = true;
        _animator.SetBool(AllStrings.Dead, false);
        _target = Player.Instance.GetComponent<Rigidbody2D>();
    }

    void DeadSet()
    {
        GameManager.Instance.Kill++;
        UIManager.Instance.UpdaateKillUI(GameManager.Instance.Kill);
        _isDead = true;
        _collider.enabled = false;
        _rigidbody.simulated = false;
        _animator.SetBool(AllStrings.Dead, true);
    }

    void Run()
    {
        if (_isDead || _animator.GetCurrentAnimatorStateInfo(0).IsName(AllStrings.Hit))
        {
            return;
        }
        Vector2 direction = _target.position - _rigidbody.position;
        Vector2 nextVector = direction.normalized * _speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVector);
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
        DropTable();
    }

    void DropTable()
    {
        int randomNumber = Random.Range(0, 100);
        switch (randomNumber)
        {
            case 77:
                if (!AchieveManager.Instance.IsRareNinjaStar)
                {
                    NinjaStarPiece ninjaStarPiece = FactoryManager.Instance.GetNinjaStarPiece();
                    ninjaStarPiece.transform.position = transform.position;
                    break;
                }
                else
                {
                    break;
                }
            default:
                ExpGem expGem = FactoryManager.Instance.GetExpGem();
                expGem.transform.position = transform.position;
                break;
        }
    }

    #region KnockBack
    Coroutine _knockBackCoHandle;

    IEnumerator KnockBackCo()
    {
        yield return _enemyDataSO.OneFixedWait;
        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 directionVector = transform.position - playerPosition;
        _rigidbody.AddForce(directionVector.normalized
                            * _enemyDataSO.KnockBackRange, ForceMode2D.Impulse);
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            StopCoroutine(coHandle);
        }
    }
    #endregion

    public void LevelValue(int level)
    {
        _speed = _enemyDataSO.Speeds[level];
        _maxHealth = _enemyDataSO.MaxHealths[level];
        _health = _maxHealth;
    }

    public void OnDamage(GameObject bullet, float damage)
    {
        if (!bullet.CompareTag(AllStrings.Bullet))
        {
            return;
        }

        _health -= damage;

        if (_health <= 0)
        {
            DeadSet();
        }
    }

}
