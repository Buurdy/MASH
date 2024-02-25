using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    PlayerController player;
    int returnedSoldiers, soldiersToRescue;
    GameObject[] woundedSoldiers;
    TMP_Text returnedSoldiersText, soldiersHeldText, winTime;
    Canvas winScreen;
    AudioSource returnSoldierAudio, winAudio;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        returnedSoldiersText = GameObject.Find("Returned Soldiers Text").GetComponent<TMP_Text>();
        soldiersHeldText = GameObject.Find("Soldiers Held Text").GetComponent <TMP_Text>();
        winScreen = GameObject.Find("Win Screen").GetComponent<Canvas>();
        if(winScreen.enabled == true) winScreen.enabled = false;
        returnSoldierAudio = GameObject.Find("Return Soldier Audio").GetComponent<AudioSource>();
        winAudio = GameObject.Find("Win Audio").GetComponent<AudioSource>();
        winTime = GameObject.Find("Win Time").GetComponent<TMP_Text>();

        woundedSoldiers = GameObject.FindGameObjectsWithTag("WoundedSoldier");
        soldiersToRescue = woundedSoldiers.Length;
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
            returnSoldierAudio.Play();
        }

        if(returnedSoldiers == soldiersToRescue)
        {
            winScreen.enabled = true;
            Destroy(player.gameObject);
            winAudio.Play();
            winTime.text = "Your time was: " + Time.time + "s";
        }
    }
}
