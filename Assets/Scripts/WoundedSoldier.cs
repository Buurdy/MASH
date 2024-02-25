using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoundedSoldier : MonoBehaviour
{
    PlayerController player;
    TMP_Text soldiersHeldText;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        soldiersHeldText = GameObject.Find("Soldiers Held Text").GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (player.carriedSoldiers < 3)
            {
                Debug.Log("Picked up");
                player.carriedSoldiers++;
                Debug.Log(player.carriedSoldiers);
                Destroy(this.gameObject);
                soldiersHeldText.text = "Soldiers Held: " + player.carriedSoldiers;
            }
        }   
    }
}
