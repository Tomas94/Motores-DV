using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float jumpForce = 5f;        // Fuerza del salto
    public float wallCheckDistance = 0.5f;   // Distancia para verificar la pared
    public Transform wallCheck;         // Punto de verificación de la pared
    public LayerMask wallLayer;         // Capa de la pared
    public float wallJumpTime = 0.5f;    // Tiempo durante el cual se permite realizar el wall jump

    private bool isTouchingWall;        // Indica si está tocando una pared
    private float wallJumpTimer;        // Temporizador para permitir el wall jump
    public bool canWallJump;           // Indica si se puede realizar el wall jump

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, wallLayer);

        // Verificar si se puede realizar el wall jump
        if (isTouchingWall && rb.velocity.y <= 0)
        {
            canWallJump = true;
            wallJumpTimer = wallJumpTime;
        }
        else
        {
            canWallJump = false;
        }

        // Realizar el wall jump
        if (canWallJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(-transform.right.x * jumpForce, jumpForce);
            wallJumpTimer = 0f;
            canWallJump = false;
        }

        // Reducir el tiempo para realizar el wall jump
        if (wallJumpTimer > 0)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }
}
