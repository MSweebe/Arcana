using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMSelector : MonoBehaviour
{
    public AudioSource[] BGM;
    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //Check to see what scene is loaded and assign correct BGM
        if (sceneName == "Level_02" && BGM.Length >= 1)
        {
            BGM[0].Play();
        }
        else if (sceneName == "Level 0" && BGM.Length >= 2)
        {
            BGM[1].Play();
        }
        else
        {
            //do nothing
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
