using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithinTime : MonoBehaviour
{
    [SerializeField]
    private float timeToLive = 2;
    
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
