using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private MovePlayer _player;

    private void Start()
    {
        _currentGameState = State.NotStarted;
    }

    public void StartGame()
    {
        if (_currentGameState == State.NotStarted)
        {
            _currentGameState = State.Playing;
            // Occurs when the player presses the button for the first time
            // Set the game state to playing
        } 
    }

    public void EndGameFail()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
        }
        else
        {
            Debug.Log("Game Failed");
            _currentGameState = State.Failure;
            _player.gameFailed = true;
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(4.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void EndGameWin()
    {
        // Occurs when the timer runs out and the windows are still in tact
    }
}
