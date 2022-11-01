using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField]
    private AudioClip sound;
    
    public IEnumerator PlayAudio(float volume)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>() as AudioSource;
        audio.clip = sound;
        audio.volume = Mathf.Min(volume, 0.8f);
        audio.pitch = Random.Range(0.8f,1.3f);
        audio.Play();

        yield return new WaitWhile (() => audio.isPlaying);
    
        Destroy(audio);
    }
}
