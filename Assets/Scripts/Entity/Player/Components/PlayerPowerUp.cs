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

    public PowerUpState state;

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


}
