using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLineSpawner : MonoBehaviour
{
    public GameObject cubes;
    public float timer=1.5f;
    public float Start_Cor = 65f;
    public float End_cor = -65f;

    private float time1;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLines();
        time1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(time1<=0)
        //{
        //    Instantiate(cubes, transform.position,Quaternion.identity);
        //    time1 = timer;
        //}
        //time1 -= Time.deltaTime;
    }
    void SpawnLines()
    {
        for (float i = Start_Cor; i>End_cor ; i -= 2.5f)
        {
            Instantiate(cubes,new Vector3(0, -1.3f, i), Quaternion.identity);
        }
    }
}