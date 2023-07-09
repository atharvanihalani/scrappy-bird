using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarStump : MonoBehaviour
{
    /*
    when clicked, 
        disappear
        change collider to trigger (which, if triggered, increments score)
        changes the sprites of the dudahs above & below

    change sprites of above & below

    Pillar.cs stores a reference to a list containing all four
    Each PillarStump stores a serialize field value of their number in stack
        gets a reference to pillar
        calls public pillar method, and passes in its num as param
    */
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
        this.myRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);
    }

    void OnMouseExit()
    {
        this.myRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        if (!this.myCollider.isTrigger)
        {
            this.myRenderer.sprite = null;
            this.myCollider.isTrigger = true;
            this.myPillar.ChangeSpritesAt(this.myNum);
            Debug.Log("clicks left: -1");
        }
    }

    public void ChangeSpriteTo(Sprite sprite)
    {
        if (this.myRenderer.sprite != null)
        {
            this.myRenderer.sprite = sprite;
        }

    }

}
