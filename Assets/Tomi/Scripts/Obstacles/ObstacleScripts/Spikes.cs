using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Obstacles, IDamageable
{
    [SerializeField] bool isStatic;
    [SerializeField] bool isHidden;

    //Posiciones
    Vector3 startPos;
    Vector3 hidePos;

    //Tiempo transicion y de espera entre estados
    float movTime = 0.5f;
    

    //direccion del hide para x: 1 Izquierda -1 Derecha para y: 1 Abajo -1 arriba
    [SerializeField] int xHide;
    [SerializeField] int yHide;

    void Start()
    {
        coolDown = 1;
        startPos = transform.position;
        hidePos = startPos - new Vector3(xHide, yHide);
    }

    void Update()
    {
        Activate();
    }

    public override void Activate()
    {
        if (isStatic) return;
        StartCoroutine(StateChange());
    }

    public override IEnumerator StateChange()
    {
        float elapsedTime;

        if (!isHidden)
        {
            isHidden = true;
            elapsedTime = 0;
            
            while (elapsedTime < movTime)
            {
                transform.position = Vector3.Lerp(startPos, hidePos, elapsedTime / movTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = hidePos;
            
            yield return new WaitForSeconds(coolDown);

            elapsedTime = 0f;

            while (elapsedTime < movTime)
            {
                transform.position = Vector3.Lerp(hidePos, startPos, elapsedTime / movTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = startPos;
            yield return new WaitForSeconds(coolDown);
            isHidden = false;
        }

    }

    public void TakeDamage(GameObject player)
    {
        Debug.Log("se intenta aplicar daño");
        PlayerController playerC = player.GetComponent<PlayerController>();

        playerC.transform.position = playerC.lastCheckPoint;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerC.currentLifes--;
        if (playerC.currentLifes <= 0) playerC.Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage(collision.gameObject);
        }
    }
}
