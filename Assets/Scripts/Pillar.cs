using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] PillarStump[] myBabies;
    [SerializeField] Sprite pillarUp;
    [SerializeField] Sprite pillarDown;
    bool isClicked = false;

    void Update()
    {
        if (transform.position.y >= -5)
        {
            transform.position = transform.position + new Vector3(-0.01f, 0, 0);
            if (transform.position.x <= -5)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Click()
    {
        this.isClicked = true;
    }

    public bool GetIsClicked()
    {
        return this.isClicked;
    }

    public void ChangeSpritesAt(int index)
    {
        switch (index)
        {
            case 0:
                myBabies[1].ChangeSpriteTo(pillarUp);
                break;
            case 1: case 2:
                myBabies[index-1].ChangeSpriteTo(pillarDown);
                myBabies[index+1].ChangeSpriteTo(pillarUp);
                break;
            case 3:
                myBabies[2].ChangeSpriteTo(pillarDown);
                break;
            default:
                Debug.Log("well, shit \r\n smtn's wrong @index: " + index);
                break;
        }
    }
}
