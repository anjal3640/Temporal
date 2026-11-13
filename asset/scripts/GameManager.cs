using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
    }

    public void AddScore(int amount)
    {
        if (IsGameOver) return;
        Score += amount;
        OnScoreChanged?.Invoke(Score);
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}