using UnityEngine;

public class DoubleJump : PowerUp
{
    PlayerCollisions _collisions;

    public DoubleJump(PlayerCollisions _pCols)
    {
        _collisions = _pCols;
    }

    public override bool CanUse()
    {
        return !_collisions.Grounded;
    }

    public override void StartAction(PlayerController player)
    {
        player.pMovement.rb.velocity = Vector2.zero;
        player.pMovement.rb.AddForce(new Vector2(0f, player.playerStats.jumpForce), ForceMode2D.Impulse);
    }
}