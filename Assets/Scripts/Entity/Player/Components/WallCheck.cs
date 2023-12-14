using System;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public event Action UpgradeWallBool;
    [SerializeField] LayerMask _wallLayer;

    bool _onWall;
    [SerializeField] float _detectionRadius;

    public bool OnWall
    {
        get { return _onWall; }
    }

    private void Update()
    {
        if (_onWall == IsOnWall()) return;
        _onWall = !_onWall;
        UpgradeWallBool?.Invoke();
    }

    bool IsOnWall() => Physics2D.OverlapCircle(transform.position, _detectionRadius, _wallLayer);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
