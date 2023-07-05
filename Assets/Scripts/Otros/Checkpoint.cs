using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerController pController;
    public  Sprite checkPointEnabled;
    public  Sprite checkPointDisabled;
    SpriteRenderer _sRenderer;
    public Transform checkPointPos;

    private void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (pController.lastCheckPoint != (Vector2)checkPointPos.position) _sRenderer.sprite = checkPointDisabled;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().lastCheckPoint = checkPointPos.position;
            _sRenderer.sprite = checkPointEnabled;
        }
    }
}
