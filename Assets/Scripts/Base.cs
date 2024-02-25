using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    PlayerController player;
    int returnedSoldiers;
    TMP_Text returnedSoldiersText, soldiersHeldText;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        returnedSoldiersText = GameObject.Find("Returned Soldiers Text").GetComponent<TMP_Text>();
        soldiersHeldText = GameObject.Find("Soldiers Held Text").GetComponent <TMP_Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.carriedSoldiers > 0)
        {
            Debug.Log("Returned soldiers");
            returnedSoldiers += player.carriedSoldiers;
            player.carriedSoldiers = 0;
            returnedSoldiersText.text = "Returned Soldiers: " + returnedSoldiers;
            soldiersHeldText.text = "Soldiers Held: 0";
        }
    }
}
