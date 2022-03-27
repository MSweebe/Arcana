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
    public float fireStart = -1;

    float fireDuration;

    void Update()
    {
        if (onFire)
        {
            if (fireStart == -1)
            {
                fireStart = Time.time;
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
                fireStart = -1;
                GameObject child = this.gameObject.transform.GetChild(0).gameObject;
                Destroy(child);
            }
        }

    }

}