using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Birb : MonoBehaviour
{
    /*
    updates rotation based on current velocity
    3: 30
    -9: -150
    */

    Rigidbody2D myRigidbody;

    void Awake()
    {
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        this.MaybeJump();
    }

    void Update()
    {
        // transform.rotation = new Vector3(0, 0, (this.myRigidbody.velocity.y - 1) * 15);

        if (transform.position.y <= -3.5f)
        {
            this.myRigidbody.velocity = Vector2.zero;
            this.myRigidbody.AddForce(10*Vector2.up, ForceMode2D.Impulse);            
        }
    }

    void MaybeJump()
    {
        // max height: 2.7; min height: -3.2
        float normalizedHeight = Mathf.Clamp01((transform.position.y + 3.2f)/(2.7f + 3.2f));
        float random = Random.value;
        if (transform.position.y <= 2.7 && random - normalizedHeight >= -0.2)
        {
            this.myRigidbody.velocity = Vector2.zero;
            this.myRigidbody.AddForce(10*Vector2.up, ForceMode2D.Impulse);
        }

        float randomTime = 0.3f + Random.Range(0, 0.4f);
        Invoke("MaybeJump", randomTime);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("DIE");
        // set animator isDead to true; stop flapping
        // stop moving carpet
    }
}
