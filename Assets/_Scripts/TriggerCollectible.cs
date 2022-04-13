using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
