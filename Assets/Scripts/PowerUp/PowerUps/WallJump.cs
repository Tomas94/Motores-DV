using System.Collections;
using UnityEngine;

public class WallJump : PowerUp
{
    PlayerCollisions _collisions;
    float _pushForce;

    public WallJump(PlayerCollisions collisions, float pushForce)
    {
        _collisions = collisions;
        _pushForce = pushForce;
    }

    public override bool CanUse()
    {
        return (_collisions.OnWall && !_collisions.Grounded);
    }

    public override void StartAction(PlayerController player)
    {
        DoWallJump(player);
    }

    void DoWallJump(PlayerController player)
    {
        player.pMovement.rb.velocity = new Vector2(-player.transform.localScale.x * _pushForce, player.playerStats.jumpForce);


        float startTime = Time.time;
        while (Time.time < startTime + activeTime) { }
        player.pMovement.rb.velocity = new Vector2(player.pMovement.rb.velocity.x, player.playerStats.jumpForce);
    }
}
