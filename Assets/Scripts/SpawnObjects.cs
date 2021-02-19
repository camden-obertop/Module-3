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
            Vector3 behindPortal = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            GameObject garbagePrefab = Instantiate(garbage, behindPortal, transform.rotation);
        }
    }
}
