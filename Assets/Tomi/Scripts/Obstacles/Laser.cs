using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Laser : Obstacles
{
    [SerializeField] LineRenderer laserLine;
    [SerializeField] Vector2 _direction;
    [SerializeField] LayerMask solids;

    //Variables para cambiar estado
    [SerializeField] bool turnON;
    public bool _coroutinePlaying;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
    }

    public override void Activate()
    {
        LaserShoot();
        if (!_coroutinePlaying)StartCoroutine(LaserSwitch());
    }

    void LaserShoot()
    {
        if (turnON)
        {
            laserLine.enabled = true;
            Vector2 startPos = transform.position;
            RaycastHit2D _hitInfo = Physics2D.Raycast(transform.position, _direction, Mathf.Infinity, solids);

            if (_hitInfo)
            {
                laserLine.SetPosition(0, startPos);
                laserLine.SetPosition(1, _hitInfo.point);
            }
            else laserLine.enabled = false;
        }
        else
        {
            laserLine.enabled = false;
        }

    }

    IEnumerator LaserSwitch()
    {
        _coroutinePlaying = true;
        turnON = !turnON;
        yield return new WaitForSeconds(coolDown);
        _coroutinePlaying = false;
    }

}
