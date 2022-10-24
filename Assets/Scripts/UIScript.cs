using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Transform target_camera;
    [SerializeField]
    private Text scoreText;
    
    void Update()
    {
        transform.LookAt(2 * transform.position - target_camera.position);
        scoreText.text = "Score: " + (Mathf.Floor(GameManager.Instance.GetScore() * 10))/10 + "%";
    }
}
