using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PowerUp
{
    public float dashVel;

    public override void Activate(GameObject player)
    {
        PlayerMovement pMovement = player.GetComponent<PlayerMovement>();
        pMovement.isDashing = true;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = pMovement.horizontalMove * dashVel;
    }

    public override void FinishAction(GameObject player)
    {
        PlayerMovement pMovement = player.GetComponent<PlayerMovement>();
        pMovement.isDashing = false;
    }
}
