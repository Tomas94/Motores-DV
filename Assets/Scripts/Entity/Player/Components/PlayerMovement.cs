using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour, IMovable
{
    public bool isDashing;
    public bool isWallJumping;
    public float velocidadActual;

    //Referencias
    Rigidbody2D _rb;

    //Variables de Movimiento y Velocidad
    public Vector2 horizontalMove;
    [SerializeField] float _maxAllowedSpeed;
    [SerializeField] float _maxDashAllowedSpeed;

    float _speed;

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        isDashing = false;
        isWallJumping = false;
    }
    private void Update()
    {
        horizontalMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        velocidadActual = _rb.velocity.x;
        FacingDirection();
    }

    public void StartMovement()
    {
        Vector2 aceleration = horizontalMove * _speed * Time.fixedDeltaTime;
        _rb.velocity += aceleration;
        if (!isDashing)
        {      
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxAllowedSpeed, _maxAllowedSpeed), _rb.velocity.y);
        }
        else
        {
            Debug.Log("Esta Dasheando");
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxDashAllowedSpeed, _maxDashAllowedSpeed), _rb.velocity.y);
        }
    }

    public void StopMovement()
    {
        Debug.Log("Se detuvo");
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    public void Jump(float jumpForce)
    {
        AudioManager.Instance.PlaySFX("Jump");
        _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void FacingDirection()
    {
        Vector2 localScale = transform.localScale;
        if (horizontalMove.x < 0) localScale.x = -1;
        else if (horizontalMove.x > 0) localScale.x = 1;
        transform.localScale = localScale;
    }
}
