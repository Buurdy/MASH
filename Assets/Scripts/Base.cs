using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    PlayerController player;
    int returnedSoldiers;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.carriedSoldiers > 0)
        {
            Debug.Log("Returned soldiers");
            returnedSoldiers += player.carriedSoldiers;
            player.carriedSoldiers = 0;
        }
    }
}
