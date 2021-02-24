using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHealth : MonoBehaviour
{
    public List<Material> windowColors;
    public int health;
    public bool dead;

    void Start()
    {
        health = 3;
        dead = false;
        UpdateWindows();
    }

    public void UpdateWindows()
    {
        foreach (Transform window in transform)
        {
            MeshRenderer meshRenderer = window.GetComponent<MeshRenderer>();
            if (health == 3)
            {
                meshRenderer.material = windowColors[0];
            } else if (health == 2)
            {
                meshRenderer.material = windowColors[1];
            } else if (health == 1)
            {
                meshRenderer.material = windowColors[2];
            } else if (health == 0)
            {
                window.GetComponent<BreakableWindowCustom>().breakWindow();
            }
        }
    }
}
