using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{ 
    public LayerMask wallLayer;
    public float radius;
    
    [SerializeField] bool onWall;
    
    public bool OnWall
    {
        get { return onWall; }
    }

    private void Update()
    {
        onWall = IsOnWall();
    }

    public bool IsOnWall()
    {
        return Physics2D.OverlapCircle(transform.position, radius, wallLayer);
    }
}
