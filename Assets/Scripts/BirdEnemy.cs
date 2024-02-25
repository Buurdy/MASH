using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    [SerializeField] float top, bottom, speed;
    bool goingToBottom = true;
    Canvas deathScreen;
    AudioSource crashAudio;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen = GameObject.Find("Death Screen").GetComponent<Canvas>();
        crashAudio = GameObject.Find("Crash Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingToBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            if(transform.position.y < bottom)
            {
                goingToBottom = false;
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            if(transform.position.y > top)
            {
                goingToBottom = true;
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            crashAudio.Play();
            deathScreen.enabled = true;
            Destroy(collision.gameObject);
        }
    }
}
