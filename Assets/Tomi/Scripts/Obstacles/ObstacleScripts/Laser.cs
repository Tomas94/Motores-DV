using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Laser : Obstacles, IDamageable
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
        if (!_coroutinePlaying) StartCoroutine(StateChange());
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
                if (_hitInfo.transform.CompareTag("Player"))
                {
                    TakeDamage(_hitInfo.transform.gameObject);
                }
            }
            else laserLine.enabled = false;
        }
        else
        {
            laserLine.enabled = false;
        }
    }

    public override IEnumerator StateChange()
    {
        if (coolDown <= 0) yield break;
        _coroutinePlaying = true;
        turnON = !turnON;
        yield return new WaitForSeconds(coolDown);
        _coroutinePlaying = false;
    }

    public void TakeDamage(GameObject player)
    {
        Debug.Log("se intenta aplicar daño");
        PlayerController playerC = player.GetComponent<PlayerController>();

        playerC.transform.position = playerC.lastCheckPoint;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerC.currentLifes--;
        AudioManager.Instance.PlaySFX("Die");
        if (playerC.currentLifes <= 0) playerC.Death();
    }
}
