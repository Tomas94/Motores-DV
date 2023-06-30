using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Entity
{
    public Vector2 lastCheckPoint;
    PlayerMovement playerMovement;
    PlayerCollisions playerCollisions;
    [SerializeField] GameObject gameOverGO;
    [SerializeField] int currentHP;

    public event EventHandler Muerte_Player;
    
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
        lastCheckPoint = transform.position;
        playerMovement?.SetSpeed(speed);
        currentLifes = MaxLifes;
    }

    private void Update()
    {
        currentHP = currentLifes;
        MovementController();
    }

    void MovementController()
    {
        if (playerMovement != null)
        {
            if (playerMovement.horizontalMove != Vector2.zero) playerMovement.StartMovement();
            else playerMovement?.StopMovement();

            if (Input.GetKeyDown(KeyCode.W) && playerCollisions.isGrounded)
            {
                playerCollisions.isGrounded = false;
                playerMovement.Jump();
            }
        }
    }

    public void Death()
    {
        Muerte_Player?.Invoke(this, EventArgs.Empty);
    }
}
