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
        if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1))
        {
            Instantiate(fire);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            // prevent spam of earth
            GameObject[] elementGO = GameObject.FindGameObjectsWithTag("Element");
            if (elementGO.Length > 0)
            {
                return;
            }
            Instantiate(earth);

        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {

            Instantiate(water);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {

            Instantiate(air);
        }
        else
        {
            return;
        }
    }
}
