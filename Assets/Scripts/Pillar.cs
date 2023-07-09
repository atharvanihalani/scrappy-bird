using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] PillarStump[] myBabies;
    [SerializeField] Sprite pillarUp;
    [SerializeField] Sprite pillarDown;

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
                Debug.Log("well, shit; smtn's wrong @index: " + index);
                break;
        }
    }
}