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
public class InteractFlood : Interactible
{
    public float duration;
    private float timeTriggered;
    private Vector3 scale;
    private bool triggered = false;
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
        // this.gameObject.SetActive(false);
        timeTriggered = Time.time;
        triggered = true;
        scale = transform.localScale;
        if (triggerObjects[0] != null)
        {
            GOTrigger[0].SetTrigger();
        }

    }

    public void FixedUpdate()
    {
        if (triggered == true)
        {
            float u = 1 - ((Time.time - timeTriggered) / duration);
            if (u < 0)
            {
                triggered = false;
            }
            scale.y *= u;
            transform.localScale = scale;
        }
    }

}
