using UnityEngine;

public class WallJump : PowerUp
{
    PlayerPowerUp player;
    Rigidbody2D rb;

    public float jumpForce = 5f;            // Fuerza del salto
    public float wallCheckDistance = 1f;    // Distancia para verificar la pared
    public Transform wallCheck;             // Punto de verificación de la pared
    public LayerMask wallLayer;             // Capa de la pared

    private bool isTouchingRightWall;            // Indica si está tocando una pared
    private bool isTouchingLeftWall;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerPowerUp>();
    }

    private void Update()
    {
        IsOnWall();
    }

    public override void Activate(GameObject player)
    {
        PlayerMovement pMovement = player.GetComponent<PlayerMovement>();
        //pMovement.Jump();
    }

  public void IsOnWall()
    {
        isTouchingRightWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, wallLayer);
        isTouchingLeftWall = Physics2D.Raycast(wallCheck.position, -transform.right, wallCheckDistance, wallLayer);

       /* if ((isTouchingRightWall || isTouchingLeftWall) && !GetComponent<PlayerCollisions>().isGrounded)
        {
            player.canUse = true;
        }
        else
        {
            player.canUse = false;
        }*/
    }
  
}
