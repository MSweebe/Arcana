using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch0 : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }

    }

    public void ExitFunction()
    {
        Application.Quit();
    }
}
