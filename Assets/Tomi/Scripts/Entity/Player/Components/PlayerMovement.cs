using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour, IMovable
{

    public Vector3 rbVelocity;

    //Referencias
    Rigidbody2D _rb;

    //Variables para Salto
    [SerializeField] int _jumpForce;

    //Variables para GroundCheck
    public LayerMask groundLayer;
    public bool isgroundTest;

    //Variables de Movimiento y Velocidad
    float xMov;
    [SerializeField] float _maxAllowedSpeed;
    float _speed;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        rbVelocity = _rb.velocity;
    }

    public void StartMovement(float direction)
    {
        float xVelocity = direction * _speed;

        if (xVelocity <= -_speed)
        {
            xVelocity = -_speed;
        }
        else if (xVelocity >= _speed)
        {
            xVelocity = _speed;
        }

        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    public void StopMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    public void Jump()
    {
        _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }
}
