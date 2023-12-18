using UnityEngine;

public class Entity : MonoBehaviour
{
    public PlayerStats playerStats = new();
    
    [Header("Variables Vida")]
    public int currentLifes;

    /*[SerializeField] protected int _maxLifes;
    [Header("Variables de Movimiento")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    public float Speed { get { return _speed; } set { _speed = value; } }
    public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }*/

    public virtual void Death()
    {
        Debug.Log("Moriste");
    }
}
