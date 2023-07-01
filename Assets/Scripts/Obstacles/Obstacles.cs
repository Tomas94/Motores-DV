using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacles : MonoBehaviour
{
    [SerializeField] protected float coolDown;

    public virtual void Activate() { }

    public abstract IEnumerator StateChange();
}
