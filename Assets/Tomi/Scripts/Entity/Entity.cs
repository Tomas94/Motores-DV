using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Variables Vida
    public int currentLifes {get;set;}
    [SerializeField] private int _maxLifes;
    private bool _isMaxLifesSet = false;
    [SerializeField] protected float speed;

    //Variables Daño

    public int MaxLifes
    {
        get { return _maxLifes; }
        
        set
        {
            if (!_isMaxLifesSet)
            {
                _maxLifes = value;
                _isMaxLifesSet = true;
            }
        }
    }


}
