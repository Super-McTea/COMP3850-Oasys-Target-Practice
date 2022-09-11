using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Movement : MonoBehaviour
{
    public float movementSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * -1 * transform.forward * movementSpeed;
    }
}
