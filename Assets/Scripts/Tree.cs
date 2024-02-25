using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    PlayerController player;
    Canvas deathScreen;
    AudioSource crashAudio;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        deathScreen = GameObject.Find("Death Screen").GetComponent<Canvas>();
        crashAudio = GameObject.Find("Crash Audio").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            crashAudio.Play();
            deathScreen.enabled = true;
            Destroy(collision.gameObject);
        }
    }
}
