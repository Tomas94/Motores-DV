using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    
    private bool _isMaxLifesSet = false;
    protected float speed;

    //Variables Vida
    public int currentLifes { get; set; }
    private int _maxLifes;
    
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
