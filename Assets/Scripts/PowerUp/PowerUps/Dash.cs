using UnityEngine;

public class Dash : PowerUp
{
    public Dash(float _activeTime)
    {
        activeTime = _activeTime;
    }

    public override void StartAction(PlayerController playerCtrl) => StartDash(playerCtrl);

    public override void FinishAction(PlayerController playerCtrl)
    {
        StopDash(playerCtrl);
        base.FinishAction(playerCtrl);
    }

    public void StartDash(PlayerController playerCtrl)
    {
        playerCtrl.Dashing = true;

        playerCtrl.pMovement.rb.gravityScale = 0;
        playerCtrl.pMovement.rb.velocity = new Vector2(playerCtrl.transform.localScale.x, 0) * (playerCtrl.Speed * 3f);
    }

    void StopDash(PlayerController playerCtrl)
    {
        playerCtrl.Dashing = false;
        playerCtrl.pMovement.rb.gravityScale = 1;
        playerCtrl.pMovement.rb.velocity = Vector2.zero;
    }
}
