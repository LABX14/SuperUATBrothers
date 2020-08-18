using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip swordSwing;
    public AudioClip footSteps;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // this plays an audio clips when A is pressed
            audioSource.clip = swordSwing;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // this plays an audio clip when W is pressed
            audioSource.clip = footSteps;
            audioSource.Play();
        }
        else
        {
            // unpause the audio if the footsteps one isn't being played
            audioSource.UnPause();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (audioSource.isPlaying)
            {
                // when the D key is pressed, then have it stop the audio that is being played in the audio source
                audioSource.Stop();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // play the sword swing in that moment. 
        AudioSource.PlayClipAtPoint(swordSwing, transform.position);
        Destroy(this.gameObject);
    }
}
