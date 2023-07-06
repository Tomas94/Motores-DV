using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour
{
    public GroundCheck groundCheck;
    public WallCheck wallCheck;

    [HideInInspector] public bool _isGrounded;
    [HideInInspector] public bool _isOnWall;

    private void Update()
    {
        _isGrounded = groundCheck.IsGroundedGetter;
        _isOnWall = wallCheck.OnWall;
    }

}
