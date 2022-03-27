using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [Header("Set in Inspector")]

    public bool onFire = false;
    public bool canFlood = false;
    public bool isFlooded = false;
    public float height;
    public float intStart = -1;

    float fireDuration;

    void Update()
    {
        if (onFire)
        {
            if (intStart == -1)
            {
                intStart = Time.time;
            }
            if (transform.childCount == 0)
            {
                Vector3 position = transform.position;
                position.y += height;
                //change mat
                Material interact_mat = Resources.Load("Interacted", typeof(Material)) as Material;
                this.gameObject.GetComponent<Renderer>().material = interact_mat;
            }
        }
        else
        {
            if (GameObject.Find("Fire Basic") != null)
            {
                float fireDuration = GameObject.Find("Fire Basic").GetComponent<Fire>().duration;
            }
            if (transform.childCount != 0)
            {
                intStart = -1;
                GameObject child = this.gameObject.transform.GetChild(0).gameObject;
                Destroy(child);
            }
            Material interact_mat = Resources.Load("Candle_Mat", typeof(Material)) as Material;
            this.gameObject.GetComponent<Renderer>().material = interact_mat;
        }

        if (isFlooded)
        {
            Vector3 newScale = transform.localScale;
            newScale.y *= 1.05f;
            transform.localScale = newScale;
            isFlooded = false;
        }

    }

}