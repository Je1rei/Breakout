using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChange : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pausePanel;

    private bool _isPause = false;

    public bool IsPause { get; private set; }

    private void Awake()
    {
        IsPause = _isPause;
    }

    private void Update()
    {
        if(_ball.Live <= 0)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        if (IsPause)
        {
            IsPause = DisablePause();
        }
        else if(!IsPause)
        {
            IsPause = EnablePause();
        }

        _pausePanel.SetActive(IsPause);
    }

    public void ResetGame()
    {
        // Добавить сохранение всего в OnApplicationQuit и OnApplicationPause
        PauseGame();
    }

    private bool EnablePause()
    {
        Time.timeScale = 0;
        return IsPause = true;
    }

    private bool DisablePause()
    {
        Time.timeScale = 1;
        return IsPause = false;
    }

    private void GameOver()
    {
        IsPause = EnablePause();
        _gameOverPanel.SetActive(true);
    }
}
