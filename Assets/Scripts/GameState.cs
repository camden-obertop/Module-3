using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum State
    {
        NotStarted,
        Playing,
        Failure,
        Success
    }

    private State _currentGameState;
    public State CurrentGameState => _currentGameState;

    private WindowHealth _windowHealth;

    private void Start()
    {
        _currentGameState = State.NotStarted;
    }

    public void StartGame()
    {
        if (_windowHealth == null)
        {
            _windowHealth = GameObject.FindGameObjectWithTag("WindowHealth").GetComponent<WindowHealth>();
        }
        if (_currentGameState == State.NotStarted)
        {
            _currentGameState = State.Playing;
            // Occurs when the player presses the button for the first time
            // Set the game state to playing
        } else if (_currentGameState == State.Failure)
        {
            _currentGameState = State.Playing;
            _windowHealth.RespawnWindows();
            // Occurs after the game ends and the player presses the button
            // Reset the windows, 
        }
    }

    public void EndGameFail()
    {
        Debug.Log("Game Failed");
        _currentGameState = State.Failure;
        StopAllCoroutines();
        // Occurs when all of the windows have been shattered
        // Stop garbage from spawning
    }

    public void EndGameWin()
    {
        // Occurs when the timer runs out and the windows are still in tact
    }
}
