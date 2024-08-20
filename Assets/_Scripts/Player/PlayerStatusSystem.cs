using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatusSystem
{
    int _enemyAttack = 10;
    float _maxHealth = 100;
    [SerializeField] float _shield;
    float _maxShield = 30;
    [SerializeField] float _health;

    int _level = 0;

    int _exp = 0;
    int[] _nextExp = new int[]
    {
        3,6,9,12,15,18,21,24,27,30
    };
    int _endExp => _nextExp.Length - 1;
    int _nextExpValue => Mathf.Min(_level, _endExp);

    bool _isDead;
    public bool IsDead => _isDead;

    [SerializeField] bool _isAtropine;
    public bool IsAtropine => _isAtropine;
    [SerializeField] WaitForSeconds _atropineTime = new WaitForSeconds(10);

    bool Dead()
    {
        if (_health <= 0)
        {
            Player.Instance.DeadAnimation();
        }
        return _health <= 0;
    }

    public void Initialize()
    {
        _health = _maxHealth;
        _isDead = false;
        _isAtropine = false;
        UIManager.Instance.UpdateHpUI(_health, _maxHealth);
        UIManager.Instance.UpdateShieldUI(_shield, _maxShield);
    }

    public void OnDamage()
    {
        if (_shield > 0)
        {
            _shield -= Time.deltaTime * _enemyAttack;
            UIManager.Instance.UpdateShieldUI(_shield, _maxShield);
        }

        else
        {
            _health -= Time.deltaTime * _enemyAttack;
            UIManager.Instance.UpdateHpUI(_health, _maxHealth);
        }
        _isDead = Dead();
    }

    public void GetExpGem()
    {
        _exp++;
        if (_exp >= _nextExp[_nextExpValue])
        {
            int tempExp = _nextExp[_nextExpValue] - _exp;
            _level++;
            _exp = tempExp;
            LevelUpUI.Instance.Show();
        }
        UIManager.Instance.UpdateExpUI(_exp, _nextExp[_nextExpValue]);
    }

    public void Healing(float healingPoint, bool isAtropine)
    {
        _health += healingPoint;
        UIManager.Instance.UpdateHpUI(_health, _maxHealth);

        if (!isAtropine)
        {
            Player.Instance.HealEffect();
            return;
        }

        if (!_isDead)
        {
            UseAtropine();
        }

        else
        {
            AchieveManager.Instance.GetMadnessTitleAchieve();
        }
    }

    public void GetBuff()
    {
        _shield = _maxShield;
        UIManager.Instance.UpdateShieldUI(_shield, _maxShield);
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
        Player.Instance.AtropineEffect(_isAtropine);
        yield return _atropineTime;
        _isAtropine = false;
        Player.Instance.AtropineEffect(_isAtropine);
    }

    void StopCoHandle(Coroutine coHandle)
    {
        if (coHandle != null)
        {
            Player.Instance.StopCoroutine(coHandle);
        }
    }
}
