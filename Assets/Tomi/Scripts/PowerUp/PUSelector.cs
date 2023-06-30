using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSelector : MonoBehaviour
{
    public enum PowerUpList
    {
        Dash,
        DoubleJump,
        WallJump
    }

    [SerializeField] PowerUpList selectedPU;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Pick up Power up");
            PlayerPowerUp player = collision.GetComponent<PlayerPowerUp>();
            player.CurrentPowerUp(selectedPU.ToString());
            if(selectedPU != PowerUpList.WallJump) player.canUse = true;
            Destroy(gameObject); 
        }
    }


}
