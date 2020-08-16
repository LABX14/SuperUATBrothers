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
            audioSource.clip = swordSwing;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.clip = footSteps;
            audioSource.Play();
        }
        else
        {
            audioSource.UnPause();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(swordSwing, transform.position);
        Destroy(this.gameObject);
    }
}
