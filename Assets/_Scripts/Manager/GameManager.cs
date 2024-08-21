using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Collider2D _allkill;
    [SerializeField] Button _startButton;
    readonly float _maxGameTime = 600;
    [SerializeField] float _gameTime;
    [SerializeField] int _level;
    [SerializeField] bool _isGame;
    public bool IsGame => _isGame;
    public bool IsKeyboard => SettingUI.Instance.IsKeyboard;

    int _maxLevel = 4;
    int _minute => Mathf.FloorToInt(_gameTime / 60);
    int _second => Mathf.FloorToInt(_gameTime % 60);

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

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void Awake()
    {
        _startButton.onClick.AddListener(() => GameStart());
        _startButton.gameObject.SetActive(true);
        _allkill = GetComponentInChildren<Collider2D>();
        Stop();
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
        _gameTime += Time.deltaTime;
        UIManager.Instance.UpdateTimeUI(_minute, _second);
        _level = (int)_gameTime / 30;

        if (_level >= _maxLevel)
        {
            _level = _maxLevel;
        }

        if (_gameTime < _maxGameTime)
        {
            return;
        }
        StartCoroutine(Victory());
    }

    void GameStart()
    {
        Resume();
        _startButton.gameObject.SetActive(false);
        _allkill.enabled = false;
        UIManager.Instance.GameStartUISetting();
        Spawner.Instance.gameObject.SetActive(true);
        LevelUpUI.Instance.Ininialize();
        LevelUpUI.Instance.Show();
    }

    IEnumerator Victory()
    {
        _allkill.enabled = true;
        yield return new WaitForSeconds(.5f);
        Stop();
        GameOverUI.Instance.Victory();
    }

    void AchieveCheck()
    {
        if (AchieveManager.Instance.IsAchieveClearEyes)
        {
            if (AchieveManager.Instance.IsAchieveHidden)
            {
                return;
            }
            if (_gameTime > 180 && Kill < 1)
            {
                AchieveManager.Instance.GetHiddenAchieve();
            }
        }

        else if (_gameTime > 60 && Kill < 1)
        {
            AchieveManager.Instance.GetClearEyesAchieve();
        }

        else
        {
            return;
        }
    }
}
