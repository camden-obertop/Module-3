using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject garbage;

    private bool _canSpawnGarbage = false;

    public float minTime;
    public float maxTime;

    private GameState _gameState;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }

    private void Update()
    {
        if (_gameState == null)
        {
            _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        } else
        {
            if (_gameState.CurrentGameState == GameState.State.Playing)
            {
                _canSpawnGarbage = true;
            } else
            {
                _canSpawnGarbage = false;
            }
        }
    }

    IEnumerator SpawnGarbage()
    {
        while(true)
        {
            if (_canSpawnGarbage)
            {
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                GameObject garbagePrefab = Instantiate(garbage, transform.position + transform.forward, transform.rotation, transform.parent);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
