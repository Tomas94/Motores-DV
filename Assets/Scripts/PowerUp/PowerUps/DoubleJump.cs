using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PowerUp
{
    public float jumpForce;

    PlayerPowerUp playerPU;
    PlayerCollisions playerCol;

    private void Start()
    {
        playerCol = GetComponent<PlayerCollisions>();
        playerPU = GetComponent<PlayerPowerUp>();     
    }

    private void Update()
    {
        if(playerCol._isGrounded) playerPU.canUse = false;
        else playerPU.canUse = true;
    }

    public override void Activate(GameObject player)
    {
        Rigidbody2D _rb = player.GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        DestroyImmediate(this);
    }
}
