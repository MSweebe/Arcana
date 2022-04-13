using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A custom trigger class for opening locked doors.
/// </summary>
/// <para>
/// Basic action: when a interactible that points to a specific door is executed, the door disappears.
/// </para>
public class TriggerDoor : Trigger
{
    public override void SetTrigger()
    {
        this.gameObject.SetActive(false);
    }
    public override void ResetTrigger()
    {
        this.gameObject.SetActive(true);
    }
}
