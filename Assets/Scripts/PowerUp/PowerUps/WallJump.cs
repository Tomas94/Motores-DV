using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : PowerUp
{
    PlayerPowerUp playerPU;
    PlayerCollisions playerCol;

    public float pushForce;
    public float jumpForce;

    private void Start()
    {
        playerCol = GetComponent<PlayerCollisions>();
        playerPU = GetComponent<PlayerPowerUp>();
        pushForce = 10;
    }

    private void Update()
    {
        if (playerCol.isOnWall && !playerCol.isGrounded) playerPU.canUse = true;
        else playerPU.canUse = false;
    }

    public override void Activate(GameObject player)
    {
        StartCoroutine(WallJumping(player));        
    }

    public override void FinishAction(GameObject player)
    {
        DestroyImmediate(this);
    }

    IEnumerator WallJumping(GameObject player)
    {
        Rigidbody2D _rb = player.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(-transform.localScale.x * pushForce, jumpForce);
        PlayerMovement playerMv = GetComponent<PlayerMovement>();
        playerMv.isWallJumping = true;
        yield return new WaitForSeconds(activeTime);
        playerMv.isWallJumping = false;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);

    }
}
