using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{

    PlayerMovement playerMovement;
    PlayerCollisions playerCollisions;
    public float xDirection;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollisions = GetComponent<PlayerCollisions>();

        if (speed != 0) return;
        else
        {
            Debug.Log("No se seteo velocidad, velocidad por defecto puesta en 10");
            speed = 10;
        }
    }


    void Start()
    {
        playerMovement?.SetSpeed(speed);
        MaxLifes = 3;
        currentLifes = MaxLifes;
    }

    private void Update()
    {
        MovementController();
        
    }

    void MovementController()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && playerMovement != null) playerMovement.StartMovement(xDirection);
        else playerMovement?.StopMovement();

        if (Input.GetKey(KeyCode.Space) && playerCollisions.isGrounded)
        {
            playerCollisions.isGrounded = false;
            playerMovement.Jump();
        }
    }

}
