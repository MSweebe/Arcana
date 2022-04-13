using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A custom trigger class for picking up collectibles.
/// </summary>
/// <para>
/// Basic action: when a interactible that points to a collectible is executed, the collectible appears.
/// </para>
public class TriggerCollectible : Trigger
{
    public override void SetTrigger()
    {
        this.gameObject.SetActive(true);
    }
    public override void ResetTrigger()
    {
        this.gameObject.SetActive(false);
    }
}
