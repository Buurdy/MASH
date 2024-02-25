using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    PlayerController player;
    Canvas deathScreen;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        deathScreen = GameObject.Find("Death Screen").GetComponent<Canvas>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            deathScreen.enabled = true;
            Destroy(collision.gameObject);
        }
    }
}
