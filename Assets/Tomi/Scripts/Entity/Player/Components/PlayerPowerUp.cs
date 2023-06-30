using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{

    bool canUsePowerUp;

    public enum PowerUpList
    {
        Dash,
        DoubleJump,
        WallBounce
    }

    public PowerUpList powerUpType;
    
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canUsePowerUp)
        {
            if(powerUpType == PowerUpList.DoubleJump)
            {

            }
        }
    } 






}
