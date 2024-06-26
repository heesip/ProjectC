using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float _gametime;
    [SerializeField] int _level;
    [SerializeField] bool _isGame;
    int _oneMinute = 60;
    int _maxLevel = 4;

    public int _minute => Mathf.FloorToInt(_gametime / 60);
    public int _second => Mathf.FloorToInt(_gametime % 60);

    public int Level => _level;

    void Awake()
    {
        _isGame = true;
        GameResourcesManager.Instance.Initialize();
        FactoryManager.Instance.Initialize();
        GameDataManager.Instance.Initialize();
    }

    private void Update()
    {
        if (!_isGame)
        {
            return;
        }
        UpdateGameTime();
        
    }

    void UpdateGameTime()
    {
        _gametime += Time.deltaTime;
        UIManager.Instance.UpdateTimeUI(_minute, _second);
        _level = (int)_gametime / _oneMinute;

        if (_level >= _maxLevel)
        {
            _level = _maxLevel;
        }
    }

}
