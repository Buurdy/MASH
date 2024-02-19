using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xInput, yInput;
    Vector3 movementVector;
    [SerializeField] float moveSpeed;
    Vector3 screenPos, playerPos;
    float leftBorder, rightBorder, topBorder, bottomBorder, distanceToCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
        ClampPlayerMovement();
    }
    
    //Gets the players input
    void GetInput()
    {
        //Gets the players horizontal input
        xInput = Input.GetAxisRaw("Horizontal");
        //Gets the players vertical input
        yInput = Input.GetAxisRaw("Vertical");
        //Stores the players input as a vector
        movementVector = new Vector3(xInput, yInput, 0);
    }

    void Movement()
    {
        //Moves the player according to their input and the players move speed
        transform.position += movementVector.normalized * moveSpeed * Time.deltaTime;
    }

    void ClampPlayerMovement()
    {
        //Gets the players current position
        playerPos = transform.position;
        //Gets the players distance from the camera
        distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        //Sets all the borders of the camera, allows for resizing.
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + this.transform.localScale.x / 2;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - this.transform.localScale.x / 2;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).y + this.transform.localScale.y / 2;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).y - this.transform.localScale.y / 2;

        //Clamps the players movement to only allow them to stay on screen
        playerPos.x = Mathf.Clamp(playerPos.x, leftBorder, rightBorder);
        playerPos.y = Mathf.Clamp(playerPos.y, topBorder, bottomBorder);
        //Sets the players position
        transform.position = playerPos;
    }
}
