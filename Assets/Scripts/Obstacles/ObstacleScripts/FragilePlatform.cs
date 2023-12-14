using System.Collections;
using UnityEngine;

public class FragilePlatform : Obstacles
{
    SpriteRenderer _sprite;
    BoxCollider2D _collider;
    CapsuleCollider2D _trigger;

    //variables de sacudida
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.1f;
    float _shakeTimer = 0f;
    public bool shaking;

    //variables para guardar posicion y rotacion inicial
    Vector2 _originalPosition;
    Quaternion _originalRotation;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _trigger = GetComponent<CapsuleCollider2D>();

        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }

    void Update()
    {
        // Activate();
    }

    /*public override void Activate()
    {
        if (_shakeTimer > 0f)
        {
            float shakeOffsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float shakeAngleZ = Random.Range(-shakeIntensity, shakeIntensity);

            //transform.position = _originalPosition + new Vector2(shakeOffsetX, 0f);
            //transform.rotation = _originalRotation * Quaternion.Euler(0f, 0f, shakeAngleZ);

            transform.SetPositionAndRotation(_originalPosition + new Vector2(shakeOffsetX, 0f), _originalRotation * Quaternion.Euler(0f, 0f, shakeAngleZ));
            _shakeTimer -= Time.deltaTime;
            return;
        }
    }*/


    public void Shake()
    {
        if (shaking) return;
        _shakeTimer = shakeDuration;
        StartCoroutine(StateChange());
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        while (_shakeTimer > 0f)
        {
            float shakeOffsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float shakeAngleZ = Random.Range(-shakeIntensity, shakeIntensity);

            transform.SetPositionAndRotation(_originalPosition + new Vector2(shakeOffsetX, 0f), _originalRotation * Quaternion.Euler(0f, 0f, shakeAngleZ));

            _shakeTimer -= Time.deltaTime;

            yield return null;
        }
    }
    
    public override IEnumerator StateChange()
    {
        shaking = true;

        yield return new WaitForSeconds(shakeDuration);

        ChangeVisibility();

        yield return new WaitForSeconds(_coolDown);

        transform.position = _originalPosition;
        transform.rotation = _originalRotation;

        ChangeVisibility();

        shaking = false;
    }

    void ChangeVisibility()
    {
        if (_sprite.enabled)
        {
            _sprite.enabled = false;
            _collider.enabled = false;
            _trigger.enabled = false;
        }
        else
        {
            _sprite.enabled = true;
            _collider.enabled = true;
            _trigger.enabled = true;
        }
    }
}
