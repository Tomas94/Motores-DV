using System.Collections;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    public PowerUpNames currentPowerUp;
    [SerializeField] float _respawnTime = 2f;

    void GivePowerUp(PlayerPowerUp playerPU)
    {
        switch (currentPowerUp)
        {
            case PowerUpNames.Dash:
                playerPU.ObtainPowerUp(new Dash(.5f));
                break;
            case PowerUpNames.DoubleJump:
                playerPU.ObtainPowerUp(new DoubleJump(playerPU.GetComponent<PlayerCollisions>()));
                break;
            case PowerUpNames.WallJump:
                playerPU.ObtainPowerUp(new WallJump(playerPU.GetComponent<PlayerCollisions>(), 10f));
                break;
        }    
    }

    IEnumerator RespawnObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(_respawnTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerPowerUp>(out var _playerPU))
        {
            GivePowerUp(_playerPU);
            StartCoroutine(RespawnObject());
        }
    }
}

public enum PowerUpNames
{
    Dash,
    DoubleJump,
    WallJump
}