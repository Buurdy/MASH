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

    void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        movementVector = new Vector3(xInput, yInput, 0);
    }

    void Movement()
    {
        transform.position += movementVector.normalized * moveSpeed * Time.deltaTime;
    }

    void ClampPlayerMovement()
    {
        playerPos = transform.position;

        distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + this.transform.localScale.x / 2;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - this.transform.localScale.x / 2;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).y + this.transform.localScale.y / 2;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).y - this.transform.localScale.y / 2;

        playerPos.x = Mathf.Clamp(playerPos.x, leftBorder, rightBorder);
        playerPos.y = Mathf.Clamp(playerPos.y, topBorder, bottomBorder);
        transform.position = playerPos;
    }
}
