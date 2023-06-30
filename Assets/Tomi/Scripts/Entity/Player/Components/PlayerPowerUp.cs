using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public PowerUp powerup;
    public bool canUse;
    public float activeTime;

    public enum PowerUpState
    {
        Locked,
        Ready,
        Active
    }

    //  public PowerUpList powerUpType;
    public PowerUpState state = PowerUpState.Locked;

    private void Update()
    {
        PowerUpStateSwitch();
    }

    void PowerUpStateSwitch()
    {
        if (!powerup) return;
        switch (state)
        {
            case PowerUpState.Ready:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    powerup.Activate(gameObject);
                    state = PowerUpState.Active;
                    activeTime = powerup.activeTime;
                }
                break;
            case PowerUpState.Active:
                canUse = false;
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = PowerUpState.Locked;
                }
                break;
            case PowerUpState.Locked:
                powerup.FinishAction(gameObject);
                powerup = null;
                if (canUse) state = PowerUpState.Ready;
                break;
        }
    }

    public void CurrentPowerUp(string powerName)
    {
        if (powerName == "Dash")
        {
            powerup = GetComponent<Dash>();
        }
        if (powerName == "DoubleJump")
        {
            powerup = GetComponent<DoubleJump>();
        }
    }


}
