using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public int jumpForce;
    [SerializeField] GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UsePU();
        }
    }

    public void Unlock()
    {
        PlayerPowerUp playerPU = GetComponent<PlayerPowerUp>();
        playerPU.powerUpType = PlayerPowerUp.PowerUpList.DoubleJump;
        return;

    }

    void UsePU()
    {
        Rigidbody2D _rb = player.GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Unlock();
        }
    }
}
