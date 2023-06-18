using UnityEngine;
using UnityEngine.Events;

public class GameOverManagerXR : MonoBehaviour
{
    public PlayerHealthXR playerHealth;       // Reference to the player's health.
    public UnityEvent OnGameOver, OnGameWin;

    public void GameOver()
    {
        OnGameOver.Invoke();
    }
    public void GameWin()
    {
        OnGameWin.Invoke();
    }
}