using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Button _startButton;

    [SerializeField] float _gametime;
    [SerializeField] int _level;
    [SerializeField] bool _isGame;
    public bool IsGame => _isGame;
    
    int _oneMinute = 60;
    int _maxLevel = 4;

    public int _minute => Mathf.FloorToInt(_gametime / 60);
    public int _second => Mathf.FloorToInt(_gametime % 60);

    public int Level => _level;
    public int Kill
    {
        get;
        set;
    }

    private void Awake()
    {
        _isGame = false;
        _startButton.onClick.AddListener(() => GameStart());
        _startButton.gameObject.SetActive(true);
    }

    void Start()
    {
        GameResourcesManager.Instance.Initialize();
        FactoryManager.Instance.Initialize();
        GameDataManager.Instance.Initialize();
        UIManager.Instance.Initialize();
        AchieveManager.Instance.Load();
    }


    void Update()
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

    void GameStart()
    {
        _isGame = true;
        _startButton.gameObject.SetActive(false);
        UIManager.Instance.GameStartUISetting();
    }
}
