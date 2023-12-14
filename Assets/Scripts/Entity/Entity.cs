using UnityEngine;

public class Entity : MonoBehaviour
{
    //Variables Vida
    [Header("Variables Vida")]
    [SerializeField] protected int _maxLifes;
    public int currentLifes;

    [Header("Variables de Movimiento")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    public float Speed { get { return _speed; } set { _speed = value; } }
    public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }

    public virtual void Death()
    {
        Debug.Log("Moriste");
    }
}
