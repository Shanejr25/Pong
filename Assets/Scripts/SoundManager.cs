using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // Store all of the sounds here
    public static SoundManager Instance = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;

    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start () {
	    
        // if the soundmanager is created
        if (Instance == null)
        {
            Instance = this;
        
        // if another sound manager was created destroy it
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
	}
	
    // play the sound with each shot
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
