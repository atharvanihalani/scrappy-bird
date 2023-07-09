using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarStump : MonoBehaviour
{
    SpriteRenderer myRenderer;
    BoxCollider2D myCollider;
    Pillar myPillar;
    [SerializeField] int myNum;
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
}
