using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject triggerObject;
    public Trigger GOTrigger;

    public void Start()
    {
        GOTrigger = triggerObject.GetComponent<Trigger>();
    }
    public virtual void Flooded() { }

    public virtual void UnFlood() { }

    public virtual void SetFire() { }

    public virtual void PutOutFire() { }

}

