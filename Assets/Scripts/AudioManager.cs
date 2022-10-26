using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicLow;
    [SerializeField]
    private AudioSource musicMed;
    [SerializeField]
    private AudioSource musicHigh;
    [SerializeField]
    private AudioSource musicFull;

    private AudioSource currentlyPlaying;

    private float score;

    [SerializeField]
    private float fadeTime = 1;
    private float fadeTimer = 0;
    [SerializeField]
    private float volume;
    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            if (value < 0)
            {
                volume = 0;
            }
            else if (value > 1)
            {
                volume = 1;
            }
            else
            {
                volume = value;
            }
        }
    }

    private MusicStates musicState;
    enum MusicStates
    {
        low,
        medium,
        high,
        full
    }
    
    void Start()
    {
        currentlyPlaying = musicFull;
        currentlyPlaying.volume = volume;
        musicState = MusicStates.low;
    }
    // Update is called once per frame
    void Update()
    {
        if (fadeTimer <= 0)
        {
            // While the music isn't trying to fade between levels, directly access the volume and score.
            currentlyPlaying.volume = volume;
            score = GameManager.Instance.GetScore();
            if (score < 25)
            {
                musicState = MusicStates.low;
            }
            else if (score < 50)
            {
                musicState = MusicStates.medium;
            }
            else if (score < 75)
            {
                musicState = MusicStates.high;
            }
            else
            {
                musicState = MusicStates.full;
            }
        }

        switch(musicState)
        {
            case MusicStates.low:
            {
                if (currentlyPlaying != musicLow)
                {
                    MusicFade(musicLow);
                }
                break;
            }
            case MusicStates.medium:
            {
                if (currentlyPlaying != musicMed)
                {
                    MusicFade(musicMed);
                }
                break;
            }
            case MusicStates.high:
            {
                if (currentlyPlaying != musicHigh)
                {
                    MusicFade(musicHigh);
                }
                break;
            }
            case MusicStates.full:
            {
                if (currentlyPlaying != musicFull)
                {
                    MusicFade(musicFull);
                }
                break;
            }
        }
    }

    private void MusicFade(AudioSource musicTo)
    {
        if (fadeTimer <= 0)
        {
            fadeTimer = fadeTime;
        }
        fadeTimer -= Time.deltaTime;
        musicTo.volume = Mathf.SmoothStep(volume, 0, fadeTimer/fadeTime);
        currentlyPlaying.volume = Mathf.SmoothStep(0, volume, fadeTimer/fadeTime);
        
        if (currentlyPlaying.volume <= 0)
        {
            currentlyPlaying = musicTo;
        }
    }
}
