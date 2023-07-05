using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour
{
    public GroundCheck groundCheck;

    [HideInInspector] public bool _isGrounded;

    private void Update()
    {
      _isGrounded = groundCheck.IsGroundedGetter;
    }

}
