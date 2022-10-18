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
    private Collider hitbox;
    public GameObject target;

    void Start()
    {
        lifeTimer = lifetime + Time.time;
        scoreTimer = scoreAge + Time.time;
        hit = false;
        active = true;
        hitbox = GetComponent<Collider>();
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {   
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
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

        if(lifeTimer < Time.time && active)
        {
            active = false;
            if(!hit)
            {
                Debug.Log("TARGET MISS");
                GameManager.Instance.Miss();
            }
            spawn.target = null;
            for (int i = 0; i < transform.childCount; i++)
            {
                    transform.GetChild(i).gameObject.SetActive(false);
            }
            hitbox.enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        hit = true;
        Debug.Log("TARGET HIT"); 
        //Just made it here for now for a workable build- ask zach the intended way
        GameManager.Instance.Hit();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);

        }
        hitbox.enabled = false;
    }

    //if collides with bullet, hit = true and gameManager.Hit()
    //if StandingTimer runs out first, gameManager.Miss()
}
