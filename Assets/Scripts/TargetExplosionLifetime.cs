using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlaySound))]
public class TargetExplosionLifetime : MonoBehaviour
{
    [SerializeField]
    private float timeToLive = 2;

    private PlaySound audioPlayer;

    
    void Start()
    {
        audioPlayer = GetComponent<PlaySound>();
        StartCoroutine(audioPlayer.PlayAudio(0.5f));
        Destroy(gameObject, timeToLive);
    }
}
