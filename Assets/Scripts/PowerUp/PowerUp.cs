using UnityEngine;

public class PowerUp
{
    public float activeTime;

    public virtual void StartAction(PlayerController player) { }

    public virtual void FinishAction(PlayerController player) { }

    public virtual bool CanUse() { return true; }
}
