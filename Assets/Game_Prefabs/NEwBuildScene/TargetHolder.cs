using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHolder : MonoBehaviour
{
    public float first_endPoint = 39f;
    public float second_endPoint = -39f;
    public float movement_Speed=2f;

    public bool dir = true;

    private int mov_dir;
    // Start is called before the first frame update
    void Start()
    {
      if (dir)
        {
            mov_dir = 1;
        }  
      else
        {
            mov_dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x>=first_endPoint || transform.position.x <= second_endPoint)
        {
            mov_dir *= -1;
        }

        transform.position += new Vector3(movement_Speed * Time.deltaTime * mov_dir, 0, 0);
    }
}
