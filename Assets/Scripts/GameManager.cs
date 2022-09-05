using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int hit, miss;
    private float scoreTimer, score;

    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
        miss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = hit / (hit + miss) * 100;
    }

    public void Hit()
    {
        hit++;
    }

    public void Miss()
    {
        miss++;
    }

    public void HitOver()
    {
        hit--;
    }

    public void MissOver()
    {
        miss--;
    }
}
