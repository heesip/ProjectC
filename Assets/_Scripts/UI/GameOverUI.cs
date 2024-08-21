using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : Singleton<GameOverUI>
{
    Button _restartButton;
    [SerializeField] GameObject _gameOverUI;
    [SerializeField] GameObject _victoryUI;

    public void Initialize()
    {
        _restartButton = GetComponentInChildren<Button>();
        _restartButton.onClick.AddListener(() => ReStart());
        UIClose();
    }

    public void Victory()
    {
        gameObject.SetActive(true);
        _victoryUI.SetActive(true);
    }

    public void GameOver()
    {
        GameManager.Instance.Stop();
        gameObject.SetActive(true);
        _gameOverUI.SetActive(true);
    }

    void UIClose()
    {
        gameObject.SetActive(false);
        _gameOverUI.SetActive(false);
        _victoryUI.SetActive(false);
    }

    void ReStart()
    {
        UIClose();
        GameManager.Instance.Restart();
    }
}
