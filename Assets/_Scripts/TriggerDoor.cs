using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
