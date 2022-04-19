using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interactible class to inherit and customize
/// </summary>
/// <para>
/// Allows extension of fire action or flood action/
/// When inherited, Interactible is meant to have methods applicable customized, all methods are generalized and empty.
/// There is also a set Trigger, for what the interactible affects.
/// Can add more triggers in inherited script if needed.
/// </para>
/// <para>
/// Must have a RigidBody attached, and Tags set to Environment_Int.
/// Layer is recommended to be set to Environment_Int.
/// </para>
public class Interactible : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject[] triggerObjects;

    [Header("Serialized")]
    public Trigger[] GOTrigger;

    public void Start()
    {
        GOTrigger = new Trigger[triggerObjects.Length];
        for (int i = 0; i < GOTrigger.Length; i++)
        {
            GOTrigger[i] = triggerObjects[i].GetComponent<Trigger>();

        }

    }
    public virtual void Flooded() { }

    public virtual void UnFlood() { }

    public virtual void SetFire() { }

    public virtual void PutOutFire() { }

}

