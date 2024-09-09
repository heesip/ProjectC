using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Collider2D _allkill;
    [SerializeField] Button _startButton;
    readonly float _maxGameTime = 420;
    [SerializeField] float _gameTime;
    [SerializeField] int _level;
    public int Level => _level;
    bool _gameStartCheck => UIManager.Instance.Joystick.gameObject.activeSelf;
    [SerializeField] bool _isGame;
    public bool IsGame => _isGame;
    public bool IsKeyboard => SettingUI.Instance.IsKeyboard;

    int _maxLevel = 5;
    int _minute => Mathf.FloorToInt(_gameTime / 60);
    int _second => Mathf.FloorToInt(_gameTime % 60);

    WaitForSeconds _victoryDelay = new WaitForSeconds(1);

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
    }

    void Start()
    {
        GameResourcesManager.Instance.Initialize();
        FactoryManager.Instance.Initialize();
        GameDataManager.Instance.Initialize();
        AudioManager.Instance.Initialize();
        UIManager.Instance.Initialize();
        AchieveManager.Instance.Load();
        Stop();
    }

    void Update()
    {
        if (!_isGame || !_gameStartCheck)
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
        _level = (int)_gameTime / 60;

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
        UIManager.Instance.GameStartUISetting();
        _startButton.gameObject.SetActive(false);
        _allkill.enabled = false;
        AudioManager.Instance.PlaySFX(SFXType.Select);
        Resume();
        AudioManager.Instance.PlayBGM();
        Spawner.Instance.gameObject.SetActive(true);
        LevelUpUI.Instance.Ininialize();
        LevelUpUI.Instance.Show();
        SettingUI.Instance.ShowUI();
    }

    IEnumerator Victory()
    {
        Spawner.Instance.gameObject.SetActive(false);
        _allkill.enabled = true;
        yield return _victoryDelay;
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
