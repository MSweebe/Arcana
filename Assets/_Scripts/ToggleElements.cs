using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleElements : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject fire;
    public GameObject water;
    public GameObject earth;
    public GameObject air;
    // Update is called once per frame
    void Update()
    {
        //toggling four basic elements with number keys
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Fire Activated");
            Instantiate(fire);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Earth Activated");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Water Activated");
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Air activated");
            Instantiate(air);
        }
        //testing purposes
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    GameObject player = GameObject.FindGameObjectWithTag("Player");
        //    player.transform.rotation *= Quaternion.Euler(0, 5f, 0);
        //}
    }
}