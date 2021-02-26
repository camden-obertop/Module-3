using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool gameFailed;

    private void Start()
    {
        gameFailed = false;
    }

    private void Update()
    {
        if (gameFailed)
        {
            transform.position = transform.position + new Vector3(0, 0, .05f);
        }
    }
}
