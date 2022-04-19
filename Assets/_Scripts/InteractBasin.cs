using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interactible class to add to basin in Unity
/// </summary>
/// <para>
/// Must have a RigidBody attached, and Tags set to Environment_Int. 
/// The candle object needs a child with a sprite renderer to be successful.
/// The prefabs contain this.
/// Layer is recommended to be set to Environment_Int.
/// </para>
public class InteractBasin : Interactible
{
    public override void Flooded()
    {
        this.gameObject.SetActive(true);
        Vector3 newScale = transform.localScale;
        newScale.y *= 1.05f;
        transform.localScale = newScale;
        GOTrigger[0].ResetTrigger();
    }

    public override void UnFlood()
    {
        this.gameObject.SetActive(false);

        if (triggerObjects[0] != null)
        {
            GOTrigger[0].SetTrigger();
        }

    }

}
