using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void SetSpeed(float speed);       //Metodo para setear la velocidad
    void StartMovement(float direction); //Encargado del movimiento
    void StopMovement();
}
