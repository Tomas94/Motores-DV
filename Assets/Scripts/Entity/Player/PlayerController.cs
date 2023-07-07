using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Entity
{
    public Vector2 lastCheckPoint;

    //Referencias
    PlayerMovement playerMovement;
    PlayerCollisions playerCollisions;

    [Header("Variables Vida")]
    [SerializeField] int _maxHP;
    [SerializeField] int _currentHP;

    [Header("Variables de Movimiento")]
    [SerializeField] float _speed;
    public float _jumpForce;

    [Header("Booleanos")]
    [SerializeField] bool _isGrounded;
    [SerializeField] bool _onWall;
    [SerializeField] bool _isHooked;

    public bool IsHooked
    {
        get { return _isHooked; }
        set { _isHooked = value; }
    }



    public event EventHandler Muerte_Player;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollisions = GetComponent<PlayerCollisions>();
    }

    void Start()
    {
        lastCheckPoint = transform.position;
        MaxLifes = _maxHP;
        currentLifes = MaxLifes;
    }

    private void Update()
    {
        UpdateVariables();
        MovementController();
        Hooked();
    }

    void MovementController()
    {
        if (playerMovement != null)
        {
            if (playerMovement.horizontalMove != Vector2.zero) playerMovement.StartMovement();
            else if(!playerMovement.isWallJumping) playerMovement?.StopMovement();

            if (Input.GetKeyDown(KeyCode.W) && _isGrounded) playerMovement.Jump(_jumpForce);
        }
    }

    public void Death()
    {
        Muerte_Player?.Invoke(this, EventArgs.Empty);
    }

    void UpdateVariables()
    {
        _isGrounded = playerCollisions._isGrounded;
        _onWall = playerCollisions._isOnWall;
        _currentHP = currentLifes;
        playerMovement?.SetSpeed(_speed);
    }

    void Hooked()
    {
        if (_isHooked) playerMovement._rb.velocity = Vector2.zero; 
    }
}
