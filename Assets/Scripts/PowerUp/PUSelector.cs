using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSelector : MonoBehaviour
{
    public float activTime;

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

            PowerUpEquip(collision.gameObject);

            PlayerPowerUp player = collision.GetComponent<PlayerPowerUp>();
            player.CurrentPowerUp(selectedPU.ToString());
            StartCoroutine(Respawn());
        }
    }

    void PowerUpEquip(GameObject collision)
    {

        switch (selectedPU)
        {
            case PowerUpList.Dash:
                if (!collision.GetComponent<Dash>()) collision.AddComponent(typeof(Dash));
                collision.GetComponent<Dash>().activeTime = activTime;
                break;
            case PowerUpList.DoubleJump:
                if (!collision.GetComponent<DoubleJump>()) collision.AddComponent(typeof(DoubleJump));
                collision.GetComponent<DoubleJump>().jumpForce = collision.GetComponent<PlayerController>()._jumpForce;
                break;
            case PowerUpList.WallJump:
                if(!collision.GetComponent<WallJump>()) collision.AddComponent(typeof(WallJump));
                collision.GetComponent<WallJump>().jumpForce = collision.GetComponent<PlayerController>()._jumpForce * 2;
                collision.GetComponent<WallJump>().activeTime = activTime;
                break;
        }
    }

    IEnumerator Respawn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
