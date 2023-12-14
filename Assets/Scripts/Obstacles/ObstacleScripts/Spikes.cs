using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Obstacles
{
    [SerializeField] bool _isStatic;
    [SerializeField] bool _isHidden;

    //Posiciones
    Vector3 _startPos;
    Vector3 _hidePos;

    //Tiempo transicion y de espera entre estados
    float _movTime = 0.5f;
    

    //direccion del hide para x: -1 Izquierda, 1 Derecha, para y: -1 Abajo, 1 arriba
    [SerializeField] int _xHide;
    [SerializeField] int _yHide;

    void Start()
    {
        _coolDown = 1;
        _startPos = transform.position;
        _hidePos = _startPos + new Vector3(_xHide, _yHide);
    }

    void Update()
    {
        Activate();
    }

    public override void Activate()
    {
        if (_isStatic) return;
        StartCoroutine(StateChange());
    }

    public override IEnumerator StateChange()
    {
        float elapsedTime;

        if (!_isHidden)
        {
            _isHidden = true;
            elapsedTime = 0;
            
            while (elapsedTime < _movTime)
            {
                transform.position = Vector3.Lerp(_startPos, _hidePos, elapsedTime / _movTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = _hidePos;
            
            yield return new WaitForSeconds(_coolDown);

            elapsedTime = 0f;

            while (elapsedTime < _movTime)
            {
                transform.position = Vector3.Lerp(_hidePos, _startPos, elapsedTime / _movTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = _startPos;
            yield return new WaitForSeconds(_coolDown);
            _isHidden = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage(collision.gameObject);
        }
    }
}
