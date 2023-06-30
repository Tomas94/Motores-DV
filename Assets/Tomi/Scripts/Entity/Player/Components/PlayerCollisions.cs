using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour
{

    //GroundCheck Variables
    // [SerializeField] GameObject _groundChecker;
    public bool isGrounded;
    
    //Variables Collider y material
    CapsuleCollider2D _pCollider;
    float _mFriction;

    private void Awake()
    {
        _pCollider = GetComponent<CapsuleCollider2D>();
    }

    void IsGrounded(GameObject colLayer, bool isEnteringTrigger)
    {
        LayerMask collisionLayer = colLayer.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer("Ground"))
        {
            if (isEnteringTrigger)
            {
                isGrounded = true;
                _mFriction = 1;
            }
            else
            {
                isGrounded = false;
                _mFriction = 0;
            }
            _pCollider.sharedMaterial.friction = _mFriction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checkea si se ta tocando el piso
        IsGrounded(collision.gameObject, true);

        if (collision.GetComponent<FragilePlatform>())
        {
            collision.GetComponent<FragilePlatform>().Shake();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Checkea si se ta dejando de tocar el piso
        IsGrounded(collision.gameObject, false);
    }

}
