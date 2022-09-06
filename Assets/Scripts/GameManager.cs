using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int hit, miss;
    private int counter = 0;
    private float scoreTimer, score;

    private string[] recentlyHits;

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
    // Start is called before the first frame update
    void Start()
    {   
        recentlyHits = new string[100];
        hit = 0;
        miss = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        int hitnum = 0;
        int missnum = 0;

        //reset the first hundred
        if (counter==100)
        {   
            counter = 0;
        }

        // count the score from last 100
        for (int i=0; i<recentlyHits.Length; i++)
        {
            if (recentlyHits[i]=="Hit")
            {
                hitnum++;
            }
            if (recentlyHits[i]=="Miss")
            {
                missnum++;
            }
        }

        hit = hitnum;
        miss = missnum;
        //Percentage of last 100
        score = hit / (hit + miss) * 100;
    }

    public void Hit()
    {   
        recentlyHits[counter] = "Hit";
        counter++;
    }

    public void Miss()
    {   
        recentlyHits[counter] = "Miss";
        counter++;
    }

    // public void HitOver()
    // {
    //     hit--;
    // }

    // public void MissOver()
    // {
    //     miss--;
    // }
}
