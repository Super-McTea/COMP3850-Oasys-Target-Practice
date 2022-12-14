using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class ShootScript : MonoBehaviour
{

    Transform gun;
    public GameObject bulletPrefab;
    float bulletSpeed;

    private PlaySound audioPlayer;
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
        if (VRDevice.Device.PrimaryInputDevice.GetButtonDown(VRButton.Trigger))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(-transform.right * bulletSpeed);
            float r = Random.value;
            float g = Random.value;
            float b = Random.value;
            Color temp = new Color(r, g, b);
            Renderer renderer = bullet.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", temp);
            renderer.material.SetColor("_EmissionColor", temp);

            TrailRenderer tr = bullet.GetComponent<TrailRenderer>();
            tr.material.SetColor("_Color", temp);
            tr.material.SetColor("_EmissionColor", temp);

            audioPlayer = GetComponent<PlaySound>();
            StartCoroutine(audioPlayer.PlayAudio(0.3f));
        }

    }

}
