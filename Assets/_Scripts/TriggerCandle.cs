using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A trigger class to flip candle states
/// </summary>
/// <para>
/// A subclass of Trigger that flips the state of any candle object.
/// sets and unsets the flame sprite.
/// </para>

public class TriggerCandle : Trigger
{
    public override void SetTrigger()
    {
        SetSprite();
    }
    public override void ResetTrigger()
    {
        SetSprite();
    }

    void SetSprite()
    {
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        if (child != null)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            sr.enabled = !sr.enabled;
        }
    }
}

