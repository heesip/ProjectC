using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatusSystem
{
    int _enemyDamage = 15;
    float _maxHealth = 100;
    [SerializeField] float _shield;
    float _maxShield = 30;
    [SerializeField] float _health;

    int _level = 0;
    int _healthUp = 25;
    int _exp = 0;
    int[] _nextExp = new int[]
    {
        5,10,10,15,20,25,30,35,40,45,50
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
            GameOverUI.Instance.GameOver();
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
            _shield -= Time.deltaTime * _enemyDamage;
            UIManager.Instance.UpdateShieldUI(_shield, _maxShield);
        }

        else
        {
            _health -= Time.deltaTime * _enemyDamage;
            UIManager.Instance.UpdateHpUI(_health, _maxHealth);
        }
        _isDead = Dead();
    }

    public void GetExpGem()
    {
        _exp++;
        AudioManager.Instance.PlaySFX(SFXType.Gem);
        if (_exp >= _nextExp[_nextExpValue])
        {
            int tempExp = _nextExp[_nextExpValue] - _exp;
            _level++;
            _exp = tempExp;
            LevelUpUI.Instance.Show();
            Healing(_healthUp, false);
        }
        UIManager.Instance.UpdateExpUI(_exp, _nextExp[_nextExpValue]);
    }

    public void Healing(float healingPoint, bool isAtropine)
    {
        _health += healingPoint;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        UIManager.Instance.UpdateHpUI(_health, _maxHealth);

        if (!isAtropine)
        {
            Player.Instance.HealEffect();
            AudioManager.Instance.PlaySFX(SFXType.Potion);
            return;
        }

        _isDead = Dead();
        if (!_isDead)
        {
            UseAtropine();
            AudioManager.Instance.PlaySFX(SFXType.Potion);
        }

        else
        {
            AchieveManager.Instance.GetMadnessTitleAchieve();
        }
    }

    public void GetBuff()
    {
        _shield = _maxShield;
        AudioManager.Instance.PlaySFX(SFXType.Shield);
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
