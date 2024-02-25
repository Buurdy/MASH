using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundedSoldier : MonoBehaviour
{
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Picked up");
            if (player.carriedSoldiers < 3)
            {
                player.carriedSoldiers++;
                Debug.Log(player.carriedSoldiers);
                Destroy(this.gameObject);
            }
        }   
    }
}
