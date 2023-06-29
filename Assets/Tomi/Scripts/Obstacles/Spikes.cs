using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Obstacles
{
    [SerializeField] bool isHidden;

    //Posiciones
    Vector3 startPos;
    Vector3 hidePos;

    //Tiempo transicion y de espera entre estados
    float movTime = 0.5f;
    float waitTime = 1;

    //direccion del hide para x: -1 Izquierda 1 Derecha para y: 1 Abajo -1 arriba


    void Start()
    {
        startPos = transform.position;
        hidePos = startPos - new Vector3(0, 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) StartCoroutine(Mov());
        StartCoroutine(Mov());
    }

    public override void Activate()
    {

    }

    /*  void MovingSpikes(string direction)
      {
          float interpolation = Time.deltaTime;
          //Vector3 movDir = new Vector3();

          switch (direction)
          {
              case "up":
                  movDir = new Vector3(0, 1);
                  break;
              case "down":
                  movDir = new Vector3(0, -1);
                  break;
              case "left":
                  movDir = new Vector3(-1, 0);
                  break;
              case "right":
                  movDir = new Vector3(1, 0);
                  break;
          }

          transform.position += movDir;

      }*/

    IEnumerator Mov()
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
            
            yield return new WaitForSeconds(waitTime);

            elapsedTime = 0f;

            while (elapsedTime < movTime)
            {
                transform.position = Vector3.Lerp(hidePos, startPos, elapsedTime / movTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = startPos;
            yield return new WaitForSeconds(waitTime);
            isHidden = false;
        }

    }
}
