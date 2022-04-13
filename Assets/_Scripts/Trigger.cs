using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A trigger class to inherit and customize
/// </summary>
/// <para>
/// Allows extension of setting and resetting triggers for systems.
/// When inherited, Trigger can be used to create custom actions for an object,
/// when the object that points to it is interacted with.
/// </para>

public class Trigger : MonoBehaviour
{
    public virtual void SetTrigger() { }
    public virtual void ResetTrigger() { }
}

