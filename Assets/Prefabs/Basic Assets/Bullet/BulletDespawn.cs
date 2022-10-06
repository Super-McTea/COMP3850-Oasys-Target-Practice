﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    [Range(1, 100)]
    public float killTime = 3;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (time >= killTime)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {   
        Destroy(this.gameObject);
        Debug.Log("Bullet Hit!");
    }
    
}
