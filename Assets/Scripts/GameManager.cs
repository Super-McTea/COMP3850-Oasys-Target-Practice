using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Keeping the history of hits and misses
    private bool[] scoreHistory;
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

    void Awake()
    {
        instance = this;
        // Initialises the score history to be all misses for now.
        scoreHistory = new bool[100];
        for (int i = 0; i < scoreHistory.Length; i++)
        {
            scoreHistory[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(hit > 0)
        // {
        //     score = hit / (hit + miss) * 100;
        // }
        // else
        // {
        //     score = 0;
        // }
        // Code above not needed for now.
        
    }

    public void Hit()
    {
        for (int i = 0; i < scoreHistory.Length-1; i++)
        {
            // Shuffling the scores down the list, also erasing the first score
            scoreHistory[i] = scoreHistory[i+1];
        }
        // Appending the latest hit to the score.
        scoreHistory[scoreHistory.Length-1] = true;

        Debug.Log("score: " + GetScore());
    }

    public void Miss()
    {
        for (int i = 0; i < scoreHistory.Length-1; i++)
        {
            // Shuffling the scores down the list, also erasing the first score
            scoreHistory[i] = scoreHistory[i+1];
        }
        // Appending the latest miss to the score.
        scoreHistory[scoreHistory.Length-1] = false;

        Debug.Log("score: " + GetScore());
    }

    // Basically undo one of the positive hits
    // This is the oonly way for the bomb to have a meaningful effect
    public void Bomb()
    {
        // for(int i = 0; i < scoreHistory.Length - 1; i++)
        // {
        //     if (scoreHistory[i] == true)
        //     {
        //         scoreHistory[i] = false;
        //         return;
        //     }
        // }

        // Previous code was good but this achieves a more devastating outcome, raising the stakes
        Miss();
        Miss();
        Miss();
        Miss();
        Miss();
    }

    ///<summary>
    ///Retrieves the current score as a number between 0 and 100.
    ///</summary>
    public float GetScore()
    {
        float score = 0;
        float scoreSum = 0;
        for (int i = scoreHistory.Length-1; i >= 0; i--)
        {
            if (scoreHistory[i])
            {
                // Weighted sum of each score, so that more recent shots have a higher impact on the total than historic shots.
                scoreSum++;
                score += WeightedScore(i);
            }
        }

        // returns the fraction of hits over total scores (e.g. 5/100 or 98/100)
        return Mathf.Min(score/scoreHistory.Length * 100, 100);
    }

    private float WeightedScore(int placeValue)
    {
        if (placeValue < 0)
        {
            return 0;
        }

        float a = 0.76f * scoreHistory.Length;
        float b = 2;
        return b - (a) / (placeValue + (a/b));

        // float l = 1.255f/scoreHistory.Length + 1;
        // return Mathf.Pow(l, placeValue);
    }
}
