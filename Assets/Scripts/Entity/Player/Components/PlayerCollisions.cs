using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour
{
    public GroundCheck groundCheck;
    public WallCheck wallCheck;

    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isOnWall;

    private void Update()
    {
        isGrounded = groundCheck.IsGroundedGetter;
        isOnWall = wallCheck.OnWall;
    }

}
