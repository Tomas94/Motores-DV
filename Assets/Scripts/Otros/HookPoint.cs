using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    public Sprite offRange;
    public Sprite onRange;
    SpriteRenderer _sRenderer;

    void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _sRenderer.sprite = onRange;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _sRenderer.sprite = offRange;
    }
}
