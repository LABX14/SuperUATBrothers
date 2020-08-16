using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip pickupSoundEffect;
    [SerializeField] private int pointValue = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSoundEffect, transform.position);
            GameManager.instance.points += pointValue;
            Destroy(this.gameObject);
        }
    }
}
