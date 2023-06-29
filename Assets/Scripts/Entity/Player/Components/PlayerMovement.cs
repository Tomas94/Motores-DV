using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour, IMovable
{
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

    public Vector2 MoveVector()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        Vector2 movimiento = new Vector2(xMov * _speed * Time.deltaTime, 0);
        return movimiento;
    }

    public void StartMovement()
    {
        float xVelocity = _rb.velocity.x;

        if (xVelocity <= _maxAllowedSpeed * -1) xVelocity = _maxAllowedSpeed * -1;
        else if (xVelocity >= _maxAllowedSpeed) xVelocity = _maxAllowedSpeed;
        else _rb.velocity += MoveVector();
    }

    public void StopMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    public void Jump()
    {
        _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }

    /*private bool IsGrounded()
    {
        Vector2 position = groundCheckObj.position;
        Vector2 direction = Vector2.down;
        float distance = groundCheckerData.checkerDistance;

        RaycastHit2D hit = Physics2D.CircleCast(position, groundCheckerData.checkerRadius, direction, distance,groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Vector2 positionGizmo = groundCheckObj.position - new Vector3(0, groundCheckerData.checkerDistance, 0);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(positionGizmo, groundCheckerData.checkerRadius);

    }*/
}
