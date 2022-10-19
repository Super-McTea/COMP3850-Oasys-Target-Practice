using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    Transform gun;
    public GameObject bulletPrefab;
    float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //Find the barrel exit where bullet can be launched from
        gun = transform.Find("BarrelExit");
        bulletSpeed = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        //If shoot button detected, spawn a bullet and launch it with random colour in that direction
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(-transform.right * bulletSpeed);
            float r = Random.value;
            float g = Random.value;
            float b = Random.value;
            Color temp = new Color(r, g, b);
            bullet.GetComponent<Renderer>().material.SetColor("_Color", temp);
        }

    }

}
