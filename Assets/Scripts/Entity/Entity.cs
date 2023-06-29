using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Variables Vida
    private int _maxHP;
    private bool isMaxHPSet = false;
    [SerializeField] protected float speed;

    //Variables Daño

    public int MaxHP
    {
        get { return _maxHP; }
        
        set
        {
            if (!isMaxHPSet)
            {
                _maxHP = value;
                isMaxHPSet = true;
            }
        }
    }


}
