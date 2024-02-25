using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Reset : MonoBehaviour
{
    Canvas deathScreen;
    private void Start()
    {
        deathScreen = GameObject.Find("Death Screen").GetComponent<Canvas>();
        if (deathScreen.enabled == true) deathScreen.enabled = false;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
