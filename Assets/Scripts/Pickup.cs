using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public AudioClip pickupSoundEffect;
    // [SerializeField] private int pointValue = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSoundEffect, transform.position); // this plays an audio when the player picks up the coin
            GameManager.instance.points += 100; // this adds a point value
            GameManager.instance.Victory();
            Destroy(this.gameObject); // this destroy the objects
        }
    }
}
