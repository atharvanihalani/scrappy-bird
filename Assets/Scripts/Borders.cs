using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    bool isDead = false;
    void Update()
    {
        if (!isDead)
        {
            transform.position = transform.position + new Vector3(-0.06f, 0, 0);
            if (transform.position.x <= -16)
            {
                transform.position = Vector3.zero;
            }
        }
    }

    public void RipBirb()
    {
        this.isDead = true;
    }
}
