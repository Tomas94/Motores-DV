using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public PowerUp powerup;
    public bool canUse;
    public float activeTime;
    public string waitingPU;

    public enum PowerUpState
    {
        Locked,
        Ready,
        Active
    }

    public PowerUpState state;

    private void Update()
    {
        PowerUpStateSwitch();
        WaitingPU();
    }

    void PowerUpStateSwitch()
    {
        if (!powerup) return;
        switch (state)
        {
            case PowerUpState.Ready:

                if (!canUse)
                {
                    state = PowerUpState.Locked;
                    break;
                }

                activeTime = powerup.activeTime;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    powerup.Activate(gameObject);
                    
                    state = PowerUpState.Active;
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
                    powerup.FinishAction(gameObject);
                    powerup = null;
                    state = PowerUpState.Locked;
                }
                break;

            case PowerUpState.Locked:
                if (canUse) state = PowerUpState.Ready;
                break;
        }
    }

    public void CurrentPowerUp(string powerName)
    {
        if (powerup != null && state == PowerUpState.Active)
        {
            waitingPU = powerName;
            return;
        }

        if (powerName == "Dash")
        {
            powerup = GetComponent<Dash>();
        }
        if (powerName == "DoubleJump")
        {
            powerup = GetComponent<DoubleJump>();
        }
        if (powerName == "WallJump")
        {
            powerup = GetComponent<WallJump>();
        }
    }

    void WaitingPU()
    {
        if (powerup == null)
        {
            if (waitingPU == "Dash")
            {
                powerup = GetComponent<Dash>();
            }
            if (waitingPU == "DoubleJump")
            {
                powerup = GetComponent<DoubleJump>();
            }
            if (waitingPU == "WallJump")
            {
                powerup = GetComponent<WallJump>();
            }
            waitingPU ="";
        }

        PowerUp[] powers = GetComponents<PowerUp>();
        foreach (PowerUp power in powers)
        {
            if (power == powerup) power.enabled = true;
            else power.enabled = false;
        }

    }

}
