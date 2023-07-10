using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Birb : MonoBehaviour
{
    [SerializeField] Background background;
    [SerializeField] GameObject restartButton;
    Rigidbody2D myRigidbody;
    SpriteRenderer myRenderer;
    Animator myAnim;
    bool isDead = false;

    void Awake()
    {
        this.myRenderer = GetComponent<SpriteRenderer>();
        this.myRigidbody = GetComponent<Rigidbody2D>();
        this.myAnim = GetComponent<Animator>();
    }

    void Start()
    {
        this.MaybeJump();
    }

    void Update()
    {
        if (transform.position.y <= -3.5f && !this.isDead)
        {
            this.myRigidbody.velocity = Vector2.zero;
            this.myRigidbody.AddForce(10*Vector2.up, ForceMode2D.Impulse);            
        }
    }

    void MaybeJump()
    {
        if (!isDead)
        {
            // max height: 2.7; min height: -3.2
            float normalizedHeight = Mathf.Clamp01((transform.position.y + 3.2f)/(2.7f + 3.2f));
            float random = Random.value;
            if (transform.position.y <= 2.7 && random - normalizedHeight >= -0.2)
            {
                this.myRigidbody.velocity = Vector2.zero;
                this.myRigidbody.AddForce(10*Vector2.up, ForceMode2D.Impulse);
            }

            float randomTime = 0.5f + Random.Range(0, 0.4f);
            Invoke("MaybeJump", randomTime);
        }
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "spikes")
        {
            Debug.Log("Ripppppp");
            this.isDead = true;
            this.myRigidbody.constraints = RigidbodyConstraints2D.None;
            transform.Rotate(0, 0, -60);
            this.myRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);

            this.background.FInChat();
            Destroy(myAnim);

            StartCoroutine(this.DisplayRestart());

        }
    }

    IEnumerator DisplayRestart()
    {
        yield return new WaitForSeconds(3);
        this.restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
