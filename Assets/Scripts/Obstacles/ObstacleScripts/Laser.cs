using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Laser : Obstacles
{
    [SerializeField] LineRenderer _laserLine;
    [SerializeField] Vector2 _direction;
    [SerializeField] LayerMask _solids;

    //Variables para cambiar estado
    [SerializeField] bool _turnON;
    public bool coroutinePlaying;

    void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
    }

    public override void Activate()
    {
        LaserShoot();
        if (!coroutinePlaying) StartCoroutine(StateChange());
    }

    void LaserShoot()
    {
        if (_turnON)
        {
            _laserLine.enabled = true;
            Vector2 startPos = transform.position;
            RaycastHit2D _hitInfo = Physics2D.Raycast(transform.position, _direction, Mathf.Infinity, _solids);

            if (_hitInfo)
            {
                _laserLine.SetPosition(0, startPos);
                _laserLine.SetPosition(1, _hitInfo.point);
                if (_hitInfo.transform.CompareTag("Player"))
                {
                    TakeDamage(_hitInfo.transform.gameObject);
                }
            }
            else _laserLine.enabled = false;
        }
        else
        {
            _laserLine.enabled = false;
        }
    }

    public override IEnumerator StateChange()
    {
        if (_coolDown <= 0) yield break;
        coroutinePlaying = true;
        _turnON = !_turnON;
        yield return new WaitForSeconds(_coolDown);
        coroutinePlaying = false;
    }
}
