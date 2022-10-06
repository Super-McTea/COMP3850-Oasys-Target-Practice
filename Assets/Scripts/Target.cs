using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float scoreAge, lifetime;
    private float scoreTimer, lifeTimer;
    public TargetSpawner spawner;
    private bool hit;
    private bool active;
    public TargetSpawner spawn;

    void Start()
    {
        lifeTimer = lifetime + Time.time;
        scoreTimer = scoreAge + Time.time;
        hit = false;
        active = true;
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
            Debug.Log("Score age over");
            Destroy(gameObject);
        }

        if(lifeTimer < Time.time && active)
        {
            active = false;
            if(!hit)
            {
                GameManager.Instance.Miss();
            }
            spawn.target = null;
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            Debug.Log("Took too long to hit");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Hit();
        Debug.Log("TARGET HIT");
    }

    void Hit()
    {
        //Destroy(gameObject);
        //GameManager.Instance.Score();
        hit = true;
    }

    //if collides with bullet, hit = true and gameManager.Hit()
    //if StandingTimer runs out first, gameManager.Miss()
}
