using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChange : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _mainMenuPanel;

    private bool _isPause = false;
    private bool _isOver = false;

    public bool IsOver { get; private set; }
    public bool IsPause { get; private set; }

    private void Awake()
    {
        EnablePause();
        IsOver = _isOver;
        IsPause = _isPause;
    }

    private void Update()
    {
        IsOver = isOver();

        if (IsOver)
        {
            GameOver();
        }

        Debug.Log(IsOver + " - IsOver");
    }

    public void ResetRound()
    {
        _mainMenuPanel.SetActive(false);
        _ball.ResetBall();
        _ball.ResetLive();
        _levelGenerator.DestroyLevel();
        _levelGenerator.GenerateLevel();
        IsPause = DisablePause();
        _gameOverPanel.SetActive(false);
    }

    public void ExitMainMenu()
    {
        _mainMenuPanel.SetActive(true);
    }

    public void Play()
    {
        ResetRound();
        DisablePause();
    }

    public void TooglePause()
    {
        if (!IsPause)
        {
            _gameOverPanel.SetActive(!IsPause);
            EnablePause();
            IsPause = true;
        }
        else if (IsPause)
        {
            _gameOverPanel.SetActive(!IsPause);
            DisablePause();
            IsPause = false;
        }
    }

    private bool EnablePause()
    {
        Time.timeScale = 0;
        return true;
    }

    private bool DisablePause()
    {
        Time.timeScale = 1;
        return false;
    }

    private void GameOver()
    {
        IsPause = EnablePause();
        _gameOverPanel.SetActive(true);
    }

    private bool isOver()
    {
        if (_ball.Live <= 0)
        {
            return true;
        }

        return false;
    }
}
