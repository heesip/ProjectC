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
        AudioManager.Instance.PlaySFX(SFXType.Win);
    }

    public void GameOver()
    {
        GameManager.Instance.Stop();
        gameObject.SetActive(true);
        _gameOverUI.SetActive(true);
        AudioManager.Instance.PlaySFX(SFXType.Lose);
    }

    void UIClose()
    {
        gameObject.SetActive(false);
        _gameOverUI.SetActive(false);
        _victoryUI.SetActive(false);
        AudioManager.Instance.PlaySFX(SFXType.Select);
    }

    void ReStart()
    {
        UIClose();
        GameManager.Instance.Restart();
        AudioManager.Instance.PlaySFX(SFXType.Select);
    }
}
