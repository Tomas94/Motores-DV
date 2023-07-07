using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PowerUp
{
    float dashVel;

    PlayerPowerUp playerPU;

    private void Start()
    {
        playerPU = GetComponent<PlayerPowerUp>();
        playerPU.canUse = true;
    }

    private void Update()
    {
        playerPU.canUse = true;
    }

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
            pMovement.horizontalMove = Vector2.zero;
            dashVel = pMovement.GetSpeed() * 1.5f;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(transform.localScale.x,0) * dashVel;
        }
        else
        {
            pMovement.isDashing = false;
            rb.gravityScale = 1;
            rb.velocity = Vector2.zero;
        }
    }



}
