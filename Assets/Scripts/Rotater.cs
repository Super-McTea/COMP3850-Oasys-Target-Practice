using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 10;

    private Vector3 start;
    private Vector3 end;

    private int direction = 1;
    private float step = 0;

    void Start()
    {
        start = transform.position;
        end = transform.position + (Vector3.up * rotationSpeed);
    }
    void Update()
    {
        if (step < 0 || step > 1)
        {
            direction = -direction;
            step += Time.deltaTime/rotationSpeed * direction;
            // Extra line to prevent it from getting stuck
        }
        step += Time.deltaTime/rotationSpeed * direction;
        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        transform.position = Vector3.Lerp(start, end, step);
    }
}
