using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLineSpawner : MonoBehaviour
{
    public GameObject cubes;
    public float timer=1.5f;

    private float time1;
    // Start is called before the first frame update
    void Start()
    {
        time1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time1<=0)
        {
            Instantiate(cubes, transform.position,Quaternion.identity);
            time1 = timer;
        }
        time1 -= Time.deltaTime;
    }
}
