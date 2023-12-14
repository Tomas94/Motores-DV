using UnityEngine;
using System.Collections;
using System;

public class PlayerController : Entity
{
    public event Action Muerte_Player;

    [HideInInspector] public Vector2 lastCheckPoint;  //------------

    //Componentes
    [HideInInspector] public PlayerMovement pMovement;
    [HideInInspector] public PlayerCollisions pCollisions;
    [HideInInspector] public PlayerPowerUp pPowerUp;

    [Header("Booleanos")]
    [SerializeField] bool _dashing = false;
    [SerializeField] bool _hooked;

    public bool Dashing { get { return _dashing; } set { _dashing = value; } }
    public bool IsHooked
    {
        get { return _hooked; }
        set { _hooked = value; }
    }      //------------

    private void Awake()
    {
        pMovement = GetComponent<PlayerMovement>();
        pCollisions = GetComponent<PlayerCollisions>();
        pPowerUp = GetComponent<PlayerPowerUp>();

        playerStats.speed = 10;
        playerStats.jumpForce = 5;
        playerStats.maxLifes = 3;

        lastCheckPoint = transform.position;
        currentLifes = playerStats.maxLifes;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pPowerUp.puState == PowerUpState.Ready) pPowerUp.TryUsePowerUp(this);

        MovementController();

        Hooked();
    }

    void MovementController()
    {
        if (!pMovement || Dashing) return;

        if (pMovement.horizontalDir != Vector2.zero) pMovement.Move(playerStats.speed);
        else pMovement.StopMove();

        if (Input.GetKeyDown(KeyCode.W) && pCollisions.Grounded) pMovement.Jump(playerStats.jumpForce);
    }

    public override void Death()
    {
        Muerte_Player?.Invoke();
    }

    IEnumerator DashCoroutine()
    {
        while (Dashing) 
        {
            pMovement.horizontalDir = Vector2.zero; 
            yield return null;
        }     //experimental
    }

    void Hooked()
    {
        if (_hooked) pMovement.rb.velocity = Vector2.zero;
    }
}
