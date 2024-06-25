using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatusSystem
{
    int _enemyAttack = 10;
    float _maxHealth = 100;
    [SerializeField] float _shield;
    public float Shield => _shield;
    float _maxshield = 50;
    [SerializeField] float _health;
    public float Health => _health;

    int _level = 0;
    public int Level => _level;

    int _exp = 0;
    public int Exp => _exp;
    int[] _nextExp = new int[]
    {
        3,6,9,12,15,18,21
    };
    public int[] NextExp => _nextExp;

    [SerializeField] bool _isDead;
    public bool IsDead => _isDead;

    [SerializeField] bool _isAtropine;
    public bool IsAtropine => _isAtropine;
    [SerializeField] WaitForSeconds _atropineTime = new WaitForSeconds(10);


    public void Initialize()
    {
        _health = _maxHealth;
        _isDead = false;
        _isAtropine = false;
    }

    public void OnDamage()
    {
        if (_shield > 0)
        {
            _shield -= Time.deltaTime * _enemyAttack;
        }

        else
        {
            _health -= Time.deltaTime * _enemyAttack;
        }
        Dead();
    }

    public void GetExpGem()
    {
        _exp++;
        if (_exp >= _nextExp[_level])
        {
            int tempExp = _nextExp[Level] - _exp;
            _level++;
            _exp = tempExp;
        }
        UIManager.Instance.UpdateExpUI();
    }

    public void Healing(float healingPoint, bool isAtropine)
    {
        _health += healingPoint;
        if (!isAtropine)
        {
            return;
        }
        UseAtropine();
        Dead();
    }

    public void GetBuff()
    {
        _shield = _maxshield;
    }

    void Dead()
    {
        if (_health <= 0)
        {
            _isDead = true;
        }
    }

    void UseAtropine()
    {
        StopCoHandle(_atropineCoHandle);
        _atropineCoHandle = Player.Instance.StartCoroutine(UseAtropineCo());
    }

    Coroutine _atropineCoHandle;
    IEnumerator UseAtropineCo()
    {
        _isAtropine = true;
        yield return _atropineTime;
        _isAtropine = false;
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            Player.Instance.StopCoroutine(coHandle);
        }
    }
}
