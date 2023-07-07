using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] bool isGrounded;
    public LayerMask groundLayer;

    public bool IsGroundedGetter
    {
        get { return isGrounded; }
    }

    bool IsGrounded(GameObject colLayer, bool isOnFloor)
    {
        LayerMask collisionLayer = colLayer.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer("Ground"))
        {
            return isOnFloor;    
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Checkea si se ta tocando el piso
        if (groundLayer == (groundLayer | (1 << collision.gameObject.layer)))
        {
            isGrounded = IsGrounded(collision.gameObject, true);
        }
        

        if (collision.GetComponent<FragilePlatform>())
        {
            collision.GetComponent<FragilePlatform>().Shake();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Checkea si se ta dejando de tocar el piso
        if (groundLayer == (groundLayer | (1 << collision.gameObject.layer)))
        {
            isGrounded = IsGrounded(collision.gameObject, false);
        }
        
    }

}
