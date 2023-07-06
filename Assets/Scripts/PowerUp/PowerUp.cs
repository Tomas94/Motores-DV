using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float activeTime;

    public virtual void Activate(GameObject player) { }

    public virtual void FinishAction(GameObject player) { }
}
