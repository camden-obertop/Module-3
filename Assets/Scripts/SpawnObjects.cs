using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject garbage;

    private bool _canSpawnGarbage = true;

    private void Start()
    {
        StartCoroutine(SpawnGarbage());
    }

    IEnumerator SpawnGarbage()
    {
        while(_canSpawnGarbage)
        {
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            GameObject garbagePrefab = Instantiate(garbage, transform.position + transform.forward, transform.rotation, transform.parent);
        }
    }
}
