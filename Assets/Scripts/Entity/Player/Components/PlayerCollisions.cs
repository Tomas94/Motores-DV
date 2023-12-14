using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    GroundCheck _groundCheck;
    WallCheck _wallCheck;

    [SerializeField] bool _grounded;
    [SerializeField] bool _onWall;

    public bool Grounded { get { return _grounded; } }
    public bool OnWall { get { return _onWall; } }

    private void Awake()
    {
        _groundCheck = GetComponentInChildren<GroundCheck>();
        _wallCheck = GetComponentInChildren<WallCheck>();
    }

    private void Start()
    {
        _groundCheck.UpdateGroundBool += UpdateGroundCheck;
        _wallCheck.UpgradeWallBool += UpdateWallCheck;
    }

    void UpdateGroundCheck() => _grounded = _groundCheck.IsGrounded;

    void UpdateWallCheck() => _onWall = _wallCheck.OnWall;
}
