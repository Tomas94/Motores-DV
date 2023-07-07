using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : Obstacles
{

    SpriteRenderer sprite;
    BoxCollider2D collider;
    CapsuleCollider2D trigger;

    //variables de sacudida
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.1f;
    private float shakeTimer = 0f;
    public bool shaking;

    //variables para guardar posicion y rotacion inicial
    private Vector2 originalPosition;
    private Quaternion originalRotation;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        trigger = GetComponent<CapsuleCollider2D>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        Activate();
    }

    public override void Activate()
    {
        if (shakeTimer > 0f)
        {
            float shakeOffsetX = Random.Range(-shakeIntensity, shakeIntensity);

            float shakeAngleZ = Random.Range(-shakeIntensity, shakeIntensity);

            transform.position = originalPosition + new Vector2(shakeOffsetX, 0f);
            transform.rotation = originalRotation * Quaternion.Euler(0f, 0f, shakeAngleZ);

            shakeTimer -= Time.deltaTime;
            return;
        }
    }

    public void Shake()
    {
        if (shaking) return;
        shakeTimer = shakeDuration;
        StartCoroutine(StateChange());
    }

    public override IEnumerator StateChange()
    {
        shaking = true;
        
        yield return new WaitForSeconds(shakeDuration);

        ChangeVisibility();

        yield return new WaitForSeconds(coolDown);
        
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        ChangeVisibility();

        shaking=false;
    }

    void ChangeVisibility()
    {
        if (sprite.enabled)
        {
            sprite.enabled = false;
            collider.enabled = false;
            trigger.enabled = false;
        }
        else
        {
            sprite.enabled = true;
            collider.enabled = true;
            trigger.enabled = true;
        }
    }


}
