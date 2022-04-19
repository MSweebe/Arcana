using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interactible class to add to candle in Unity
/// </summary>
/// <para>
/// Must have a RigidBody attached, and Tags set to Environment_Int. 
/// The candle object needs a child with a sprite renderer to be successful.
/// The prefabs contain this.
/// Layer is recommended to be set to Environment_Int.
/// </para>
public class InteractCandle : Interactible
{

    public override void SetFire()
    {
        setSprite(true);
        if (triggerObjects != null)
        {
            for (int i = 0; i < triggerObjects.Length; i++)
            {
                if (GOTrigger[i] != null)
                {
                    GOTrigger[i].SetTrigger();
                }

            }

        }
    }
    public override void PutOutFire()
    {
        setSprite(false);
        if (triggerObjects != null)
        {
            for (int i = 0; i < triggerObjects.Length; i++)
            {
                if (GOTrigger[i] != null)
                {
                    GOTrigger[i].ResetTrigger();
                }
            }
        }
    }

    void setSprite(bool isActive)
    {
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        if (child != null)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            sr.enabled = isActive;
        }
    }
}
