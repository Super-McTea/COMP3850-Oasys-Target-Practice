using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float scoreAge;
    private float scoreTimer;
    private bool hit;

    void Start()
    {
        scoreTimer = scoreAge;
        hit = false;
    }

    private void Update()
    {
        if(scoreTimer < Time.time)
        {
            if(hit)
            {
                GameManager.Instance.HitOver();
            }
            else
            {
                GameManager.Instance.MissOver();
            }
            Destroy(gameObject);
        }
    }

    void Hit()
    {
        //Destroy(gameObject);
        //GameManager.Instance.Score();
    }

    //if collides with bullet, hit = true and gameManager.Hit()
    //if StandingTimer runs out first, gameManager.Miss()
}
