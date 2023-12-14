using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public event Action UpdateGroundBool;
    [SerializeField] LayerMask _groundLayer;

    bool _grounded;

    public bool IsGrounded
    {
        get { return _grounded; }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FragilePlatform _platform)) _platform.Shake(); //Verifica si se esta sobre una plataforma fragil;       

        //Checkea si se ta tocando el piso
        if (_grounded) return;

        _grounded = (_groundLayer == (_groundLayer | (1 << collision.gameObject.layer)));
        UpdateGroundBool?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _grounded = false;
        UpdateGroundBool?.Invoke();
    }
}
