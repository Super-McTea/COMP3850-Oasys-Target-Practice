using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifetime = 3;
    private float lifeTimer = 0;
    private bool hit;
    private Collider hitbox;
    public GameObject target;

    private Animator anim;
    private bool spawned;

    void Start()
    {   
        anim = GetComponent<Animator>();
        lifeTimer = lifetime + Time.time;
        hit = false;
        hitbox = GetComponent<Collider>();
        target = GameObject.FindWithTag("Player");
        spawned = false;
    }

    private void Update()
    {   
        if (!spawned)
        {
            anim.SetBool("Spawned", true);
            spawned = true;
        }
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if(lifeTimer < Time.time)
        {
            if(!hit)
            {
                Debug.Log("TARGET MISS");
                GameManager.Instance.Miss();
                anim.SetTrigger("Despawn");
            }
            Destroy(gameObject,1.5f);
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
