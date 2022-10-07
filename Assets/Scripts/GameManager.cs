using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float scoreTimer, score, hit, miss;
    static private GameManager instance;

    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is no GameManager instance in the scene.");
            }
            return instance;
        }
    }

    void Start()
    {
        instance = this;
        hit = 0;
        score = 0;
        miss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(hit > 0)
        {
            score = hit / (hit + miss) * 100;
        }
        else
        {
            score = 0;
        }
    }

    public void Hit()
    {
        hit++;
        Debug.Log("score: " + score);
    }

    public void Miss()
    {
        miss++;
        Debug.Log("score: " + score);
    }

    public void HitOver()
    {
        hit--;
    }

    public void MissOver()
    {
        miss--;
    }

    public float GetScore()
    {
        return score;
    }
}
