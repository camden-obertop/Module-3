using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHealth : MonoBehaviour
{
    public List<Material> windowColors;
    public int health;
    public bool dead;
    public GameObject windowPrefab;

    private GameState _gameState;
    private List<Transform> _windowTransforms = new List<Transform>();

    void Start()
    {
        health = 3;
        dead = false;
        UpdateWindows();
    }

    public void UpdateWindows()
    {
        if (_gameState == null)
        {
            _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        }
        else
        {
            foreach (Transform window in transform)
            {
                _windowTransforms.Add(window);
                MeshRenderer meshRenderer = window.GetComponent<MeshRenderer>();
                if (health == 3)
                {
                    meshRenderer.material = windowColors[0];
                }
                else if (health == 2)
                {
                    meshRenderer.material = windowColors[1];
                }
                else if (health == 1)
                {
                    meshRenderer.material = windowColors[2];
                }
                else if (health == 0)
                {
                    window.GetComponent<BreakableWindowCustom>().breakWindow();
                    // End Game
                    _gameState.EndGameFail();
                }
            }
        }
    }

    public void RespawnWindows()
    {
        foreach (Transform window in _windowTransforms)
        {
            Instantiate(windowPrefab, window.position, window.rotation, transform);
        }
    }
}
