using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChange : MonoBehaviour
{
    Renderer render;
    public float delaytime;

    void Start()
    {
        render = GetComponentInChildren<Renderer>();
        InvokeRepeating("ChangeColor", 2f, delaytime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor()
    {
        if (render.gameObject.CompareTag("Red"))
        {
            render.material.color = Color.green;
            render.gameObject.tag = "Green";
        }
        else if (render.gameObject.CompareTag("Green"))
        {
            render.material.color = Color.red;
            render.gameObject.tag = "Red";
        }
    }
}
