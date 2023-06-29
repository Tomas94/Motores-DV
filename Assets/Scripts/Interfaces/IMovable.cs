using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void SetSpeed(float speed);       //Metodo para setear la velocidad
    Vector2 MoveVector(); //Metodo encargado del Vector Movimiento y su direccion en X
    void StartMovement(); //Encargado del movimiento
    void StopMovement();
}
