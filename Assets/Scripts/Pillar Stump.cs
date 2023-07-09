using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PillarStump : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] int myNum;
    bool beenTriggered = false;
    SpriteRenderer myRenderer;
    BoxCollider2D myCollider;
    Pillar myPillar;
    void Awake()
    {
        this.myRenderer = GetComponent<SpriteRenderer>();
        this.myCollider = GetComponent<BoxCollider2D>();
        this.myPillar = GetComponentInParent<Pillar>();
    }

    void OnMouseOver()
    {
        if (!this.myPillar.GetIsClicked())
        {
            this.myRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);
        }
    }

    void OnMouseExit()
    {
        this.myRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        if (!this.myPillar.GetIsClicked())
        {
            this.myRenderer.sprite = null;
            this.myCollider.isTrigger = true;
            this.myPillar.ChangeSpritesAt(this.myNum);
            this.myPillar.Click();
        }
    }

    public void ChangeSpriteTo(Sprite sprite)
    {
        this.myRenderer.sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "birb" && !this.beenTriggered)
        {
            this.beenTriggered = true;
            int scoreInt = int.Parse(score.text);
            score.text = $"{scoreInt + 1}";
        }
    }    
}
