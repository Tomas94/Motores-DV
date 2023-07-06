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
        // Aquí puedes agregar cualquier otro código necesario al iniciar el movimiento, como inhabilitar otros controles del personaje.
    }

    private void Move()
    {
        _rb.gravityScale = 0;
        // Calcula la dirección hacia el punto
        Vector3 direction = (target.position - transform.position).normalized;
        // Calcula el desplazamiento por cuadro basado en la velocidad y el tiempo transcurrido desde el último cuadro
        float displacement = speed * Time.deltaTime;
        // Mueve al personaje hacia el punto objetivo utilizando un Raycast para evitar obstáculos
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, displacement, layers);
        
        if (hit.collider != null)
        {
            StopMoving();
            return;
        }
        transform.position += direction * displacement;

        // Comprueba si el personaje ha llegado al punto objetivo
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
        // Aquí puedes agregar cualquier otro código necesario al detener el movimiento, como habilitar nuevamente los controles del personaje.
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
