using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [Header("Set in Inspector")]

    public bool onFire = false;
    public bool canFlood = false;
    public bool isFlooded = false;
    public float height;
    public float intStart = -1;

    float fireDuration;

    /// <summary>
    /// A parent Interactible that can be inherited to enact Fire and Flooding
    /// </summary>

    public virtual void SetFire()
    {

    }
    public virtual void PutOutFire()
    {

    }
    public virtual void Flooded()
    {

    }

}
