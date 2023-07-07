using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    public Sprite activated;
    SpriteRenderer _sRenderer;
    public Portal portal;

    void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sRenderer.sprite = activated;
            portal.buttonCount++;
        }
    }
}
