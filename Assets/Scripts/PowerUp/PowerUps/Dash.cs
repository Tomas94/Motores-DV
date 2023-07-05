using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PowerUp
{
    float dashVel;

    public override void Activate(GameObject player)
    {
        Dashing(player, true);
    }

    public override void FinishAction(GameObject player)
    {
        Dashing(player, false);
        DestroyImmediate(this);
    }

    public void Dashing(GameObject player, bool isActivating)
    {
        PlayerMovement pMovement = player.GetComponent<PlayerMovement>();
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (isActivating)
        {
            pMovement.isDashing = true;
            dashVel = pMovement.GetSpeed() * 1.5f;
            rb.gravityScale = 0;
            rb.velocity = pMovement.horizontalMove * dashVel;
        }
        else
        {
            pMovement.isDashing = false;
            rb.gravityScale = 1;
            rb.velocity = Vector2.zero;
        }
    }



}
