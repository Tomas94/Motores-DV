using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSelector : MonoBehaviour
{
    public enum PowerUpList
    {
        Dash,
        DoubleJump,
        WallBounce
    }

    [SerializeField] PowerUpList selectedPU;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPowerUp player = collision.GetComponent<PlayerPowerUp>();
            player.CurrentPowerUp(selectedPU.ToString());
            player.canUse = true;
            Destroy(gameObject);
        }
    }


}
