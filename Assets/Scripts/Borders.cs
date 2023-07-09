using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(-0.01f, 0, 0);
        if (transform.position.x <= -16)
        {
            transform.position = Vector3.zero;
        }
    }
}
