using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PowerUp
{
    public int jumpForce;

    public override void Activate(GameObject player)
    {
        Rigidbody2D _rb = player.GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}
