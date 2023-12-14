using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //Referencias
    [HideInInspector] public Rigidbody2D rb;

    //Variables de direccion
    [HideInInspector] public Vector2 horizontalDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    public void Move(float _speed)
    {
        FacingDirection();

        Vector2 aceleration = _speed * Time.fixedDeltaTime * horizontalDir;
        rb.velocity += aceleration;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -_speed, _speed), rb.velocity.y);        //Caminando
    }

    public void Dash(float _dashSpeed)
    {
        Vector2 aceleration = _dashSpeed * Time.fixedDeltaTime * horizontalDir;
        rb.velocity += aceleration;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -_dashSpeed, _dashSpeed), rb.velocity.y); //Dasheando
    }

    public void StopMove() => rb.velocity = new Vector2(0, rb.velocity.y);

    public void Jump(float jumpForce)
    {
        AudioManager.Instance.PlaySFX("Jump");
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void FacingDirection() => transform.localScale = horizontalDir.x < 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);

}
