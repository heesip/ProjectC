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
    public bool IsJoyStick => SettingUI.Instance.IsJoyStick;
 

    int _maxLevel = 4;
    int _minute => Mathf.FloorToInt(_gametime / 60);
    int _second => Mathf.FloorToInt(_gametime % 60);

    public int Level => _level;
    public int Kill
    {
        get;
        set;
    }

    public void Stop()
    {
        _isGame = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _isGame = true;
        Time.timeScale = 1;
    }

    void Awake()
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
        AchieveCheck();
        UpdateGameTime();
    }

    void UpdateGameTime()
    {
        _gametime += Time.deltaTime;
        UIManager.Instance.UpdateTimeUI(_minute, _second);
        _level = (int)_gametime / 60;

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
        Spawner.Instance.gameObject.SetActive(true);
        LevelUpUI.Instance.Ininialize();
        LevelUpUI.Instance.Show();
    }

    void AchieveCheck()
    {
        if (AchieveManager.Instance.IsAchieveClearEyes)
        {
            if (AchieveManager.Instance.IsAchieveHidden)
            {
                return;
            }
            if (_gametime > 180 && Kill < 1)
            {
                AchieveManager.Instance.GetHiddenAchieve();
            }
        }

        else if(_gametime > 60 && Kill < 1)
        {
            AchieveManager.Instance.GetClearEyesAchieve();
        }

        else
        {
            return;
        }
    }
}
