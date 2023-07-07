using UnityEngine;


public class HookShoot : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerController _pCtrl;

    public float speed = 5f; // Velocidad de movimiento hacia el punto
    public Transform target; // Punto hacia el cual el personaje se moverá
    public LayerMask layers;

    [SerializeField] private bool isMoving = false; // Indica si el personaje está en movimiento

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pCtrl = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving && target)
        {
            StartMoving();
        }

        if (isMoving)
        {
            Move();
        }
    }

    private void StartMoving()
    {
        _pCtrl.IsHooked = true;
        isMoving = true;
    }

    private void Move()
    {
        _rb.gravityScale = 0;
        
        Vector3 direction = (target.position - transform.position).normalized;
        
        float displacement = speed * Time.deltaTime;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, displacement, layers);
        
        if (hit.collider != null)
        {
            StopMoving();
            return;
        }
        transform.position += direction * displacement;

        // Comprueba si el player llego al punto objetivo
        if (Vector3.Distance(transform.position, target.position) < displacement)
        {
            StopMoving();
        }
    }

    private void StopMoving()
    {
        _pCtrl.IsHooked = false;
        isMoving = false;
        _rb.gravityScale = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("HookPoint"))
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HookPoint"))
        {
            target = null;
        }
    }

    
}
