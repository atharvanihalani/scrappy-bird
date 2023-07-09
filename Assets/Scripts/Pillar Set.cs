using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSet : MonoBehaviour
{
    [SerializeField] Pillar samplePillar;
    void Start()
    {
        this.MakePillar();
    }

    void MakePillar()
    {
        Instantiate(this.samplePillar, new Vector3(5, 0.4f, 0), Quaternion.identity, this.transform);

        float randomTime = Random.Range(1, 3.5f);
        Invoke("MakePillar", randomTime);
    }
}
