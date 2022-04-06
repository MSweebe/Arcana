using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCandle : Interactible
{
    void Update()
    {
        if (onFire)
        {
            if (intStart == -1)
            {
                intStart = Time.time;
                setSprite(true);
            }
        }
        else
        {
            intStart = -1;
            setSprite(false);
        }

    }
    void setSprite(bool isActive)
    {
        Debug.Log("child is gained");
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        if (child != null)
        {
            Debug.Log("Sprite Set " + isActive);
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            sr.enabled = isActive;
        }

    }
}
