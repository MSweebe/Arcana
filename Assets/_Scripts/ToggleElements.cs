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
        GameObject pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        if(pauseMenu!= null && pauseMenu.GetComponent<PauseMenu>().isPaused)
            return;

        //toggling four basic elements with number keys
        if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1))
        {
            Instantiate(fire);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {

            GameObject[] elementGO = GameObject.FindGameObjectsWithTag("Element");
            if (elementGO.Length > 0)
            {
                return;
            }
            Instantiate(earth);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {

            Instantiate(water);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {

            Instantiate(air);
        }
        //testing purposes
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.rotation *= Quaternion.Euler(0, 5f, 0);
        }
    }
}
