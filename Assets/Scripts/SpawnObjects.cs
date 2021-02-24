using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject garbage;

    private bool _canSpawnGarbage = true;

    public float minTime;
    public float maxTime;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }

    IEnumerator SpawnGarbage()
    {
        while(_canSpawnGarbage)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            GameObject garbagePrefab = Instantiate(garbage, transform.position + transform.forward, transform.rotation, transform.parent);
        }
    }
}
